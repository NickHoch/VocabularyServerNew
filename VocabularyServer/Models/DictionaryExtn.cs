using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.Models
{
    [Serializable]
    public class DictionaryExtn : Dictionary
    {
        [Required]
        public virtual CredentialExtn Credential { get; set; }
        [XmlIgnoreAttribute]
        public virtual ICollection<Word> Words { get; set; }
        public DictionaryExtn() { }
    }
}