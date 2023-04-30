using System;
using System.Collections.Generic;

namespace Course_Lib.Models
{
    public partial class Client
    {
        public Client()
        {
            Aboniments = new HashSet<Aboniment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public int? PassportSeria { get; set; }
        public int? PassportNumber { get; set; }
        public int ImageClientId { get; set; }
        public byte? Vipclient { get; set; }

        public virtual ImageClient? ImageClient { get; set; }
        public virtual ICollection<Aboniment> Aboniments { get; set; }

        //public string Fio { get => Name + "" + Lastname + "" + Family; }
    }
    
}
