using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DictionaryExtnDTO : DictionaryDTO
    {
        public CredentialExtnDTO Credential { get; set; }
        public List<WordDTO> Words { get; set; }
    }
}
