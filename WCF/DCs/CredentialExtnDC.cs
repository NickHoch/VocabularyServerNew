using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.DCs
{
    [DataContract]
    public class CredentialExtnDC : CredentialDC
    {
        [DataMember]
        public ICollection<DictionaryExtnDC> Dictionaries { get; set; }
    }
}