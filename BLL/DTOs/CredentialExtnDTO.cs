using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CredentialExtnDTO : CredentialDTO
    {
        public List<DictionaryDTO> Dictionaries { get; set; }
    }
}
