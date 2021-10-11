using System.Management;

namespace DNSHelper
{
    public class DNSUtility
    {
        public string Server;
        public string User;
        
        private ManagementScope _managementScope;
        private string _password;
        private string _nameSpace;
        
        public DNSUtility(string serverName, string userName, string password)
        {
            this.Server = serverName;
            this.User = userName;
            this._password = password;
            
            this.HandleLogon();
        }
        
        private void HandleLogon()
        {
            this._nameSpace = "\\\\" + this.Server + "\\root\\MicrosoftDNS";
            
            var connectionOptions = new ConnectionOptions();
            connectionOptions.Username = this.User;
            connectionOptions.Password = this._password;
            connectionOptions.Impersonation = ImpersonationLevel.Impersonate;
            
            this._managementScope = new ManagementScope(this._nameSpace);
            this._managementScope.Options = connectionOptions;
            this._managementScope.Connect();
        }

        public void CreateRecord(DNSRecord dnsRecord)
        {
            var managementClass = new ManagementClass(this._managementScope, new ManagementPath(dnsRecord.RecordType.ManagementPathName), null);
            var managementBaseObject = managementClass.GetMethodParameters("CreateInstanceFromPropertyData");

            managementBaseObject["DnsServerName"] = this.Server;
            managementBaseObject["ContainerName"] = dnsRecord.Domain;
            if (dnsRecord.SubDomain == null)
                managementBaseObject["OwnerName"] = dnsRecord.Domain;
            else
                managementBaseObject["OwnerName"] = dnsRecord.SubDomain + "." + dnsRecord.Domain;

            switch (dnsRecord.RecordType.Name)
            {
                case "CNAME":
                    managementBaseObject["PrimaryName"] = dnsRecord.Target;
                    break;

                case "A":
                    managementBaseObject["IPAddress"] = dnsRecord.Target;
                    break;

                default:
                    return;
            }
            managementClass.InvokeMethod("CreateInstanceFromPropertyData", managementBaseObject, null);
        }

        public void DeleteRecord(DNSRecord dnsRecord)
        {
            var sqlString = "SELECT * FROM " + dnsRecord.RecordType.ManagementPathName + " WHERE OwnerName = '" + dnsRecord.SubDomain + "." + dnsRecord.Domain + "'";
            var objectQuery = new ObjectQuery(sqlString);
            var managementObjectSearcher = new ManagementObjectSearcher(this._managementScope, objectQuery);
            var managementObjectCollection = managementObjectSearcher.Get();
            var total = managementObjectCollection.Count;
            
            foreach (var o in managementObjectCollection)
            {
                var managementObject = (ManagementObject) o;
                managementObject.Delete();
            }
        }
    }
}