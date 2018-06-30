using DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public string IsCardPassed { get; set; }
        public bool IsWordLearned { get; set; }
        public bool IsWordInProcessStuding { get; set; }
        [Required]
        public virtual DictionaryExtn Dictionary { get; set; }
    }
}