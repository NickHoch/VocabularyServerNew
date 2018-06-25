using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.DCs
{
    public class DictionaryExtnDC : DictionaryDC
    {
        [DataMember]
        public CredentialDC Credential { get; set; }
        [DataMember]
        public ICollection<WordDC> Words { get; set; }
    }
}