using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.Models
{
    [Serializable]
    public class CredentialExtn : Credential
    {
        [XmlIgnoreAttribute]
        public virtual ICollection<DictionaryExtn> Dictionaries { get; set; }
        public CredentialExtn() { }
    }
}