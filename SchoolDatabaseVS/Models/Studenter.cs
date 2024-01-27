using System;
using System.Collections.Generic;

namespace SchoolDatabaseVS.Models
{
    public partial class Studenter
    {
        public int StudentId { get; set; }
        public string? Snamn { get; set; }
        public string? PersonNummer { get; set; }
        public string? Klass { get; set; }
    }
}
