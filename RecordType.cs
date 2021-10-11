using System;

namespace DNSHelper
{
    public class RecordType
    {
        public static readonly RecordType A = new RecordType("A", "MicrosoftDNS_ATYPE");
        public static readonly RecordType CNAME = new RecordType("CNAME", "MicrosoftDNS_CNAMETYPE");

        public readonly string Name;
        public readonly string ManagementPathName;

        private RecordType(String name, string managementPathName)
        {
            this.Name = name;
            this.ManagementPathName = managementPathName;
        }
    }
}