using DAL.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;

namespace DAL
{
    [Serializable]
    public class Word
    {
        public int Id { get; set; }
        [Required, StringLength(20, MinimumLength = 1)]
        public string WordEng { get; set; }
        [Required, StringLength(20, MinimumLength = 1)]
        public string Transcription { get; set; }
        [Required, StringLength(20, MinimumLength = 1)]
        public string Translation { get; set; }
        public byte[] Sound { get; set; }
        public byte[] Image { get; set; }
        [StringLength(6, MinimumLength = 6)]
        public string IsCardPassedStr { get; set; }
        public bool[] IsCardPassed
        {
            get
            {
                return Array.ConvertAll<char, bool>(
                    IsCardPassedStr.ToCharArray(),
                    new Converter<char, bool>(c => c == '1' ? true : false ));
            }
            set
            {
                IsCardPassedStr = (Array.ConvertAll(
                    value,
                    new Converter<bool, char>(b => b == true ? '1' : '0')
                    )).Aggregate("", (a, b) => a + b);
            }
        }
        public bool IsWordLearned { get; set; }
        [Required]
        public virtual DictionaryExtn Dictionary { get; set; }
    }
}