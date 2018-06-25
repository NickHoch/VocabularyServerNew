using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace DAL
{
    [Serializable]
    public class Dictionary
    {
        public int Id { get; set; }
        [Required, StringLength(20, MinimumLength = 1)]
        public string Name { get; set; }
        public Dictionary() { }
    }
}