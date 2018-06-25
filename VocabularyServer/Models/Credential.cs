using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace DAL
{
    [Serializable]
    public class Credential
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(20)]
        public string Password { get; set; }
        public Credential() { }
    }
}