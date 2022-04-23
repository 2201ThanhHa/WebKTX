using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTX_MVC.Models
{
    public class Parrents
    {
        [Key]
        public String StudentsId { get; set; }
        public String DadName { get; set; }
        public String DadJob { get; set; }
        public String DadPhone { get; set; }
        public String Address { get; set; }
        public String MomName { get; set; }
        public String MomJob { get; set; }
        public String MomPhone { get; set; }
    }
}
