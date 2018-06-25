using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class WordDTO
    {
        public int Id { get; set; }
        public string WordEng { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
        public byte[] Sound { get; set; }
        public byte[] Image { get; set; }
        public bool IsLearnedWord { get; set; }
        public DictionaryDTO Dictionary { get; set; }
    }
}