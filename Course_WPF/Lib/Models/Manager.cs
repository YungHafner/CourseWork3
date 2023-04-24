using System;
using System.Collections.Generic;

namespace Course_Lib.Models
{
    public partial class Manager
    {
        public int Id { get; set; }
        public string? LoginManager { get; set; }
        public string? PasswordManager { get; set; }
    }
}
