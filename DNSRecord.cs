using System;
using System.Management;

namespace DNSHelper
{
    public class DNSRecord
    {
        public string Domain;
        public string SubDomain;
        public string Target;
        public RecordType RecordType;
        
        public DNSRecord(string domain, string subDomain, string target, RecordType recordType)
        {
            this.Domain = domain;
            this.SubDomain = subDomain;
            this.Target = target;
            this.RecordType = recordType;
        }
    }
}