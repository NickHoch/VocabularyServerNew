using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.DCs
{
    [DataContract]
    public class WordDC
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string WordEng { get; set; }
        [DataMember]
        public string Transcription { get; set; }
        [DataMember]
        public string Translation { get; set; }
        [DataMember]
        public byte[] Sound { get; set; }
        [DataMember]
        public byte[] Image { get; set; }
        [DataMember]
        public bool IsWordLearned { get; set; }
        [DataMember]
        public bool[] IsCardPassed { get; set; }
        [DataMember]
        public DictionaryExtnDC Dictionary { get; set; }
    }
}