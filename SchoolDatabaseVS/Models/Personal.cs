using System;
using System.Collections.Generic;

namespace SchoolDatabaseVS.Models
{
    public partial class Personal
    {
        public Personal()
        {
            Betygs = new HashSet<Betyg>();
        }

        public int PersonalId { get; set; }
        public string? Namn { get; set; }
        public string? YrkesRoll { get; set; }

        public virtual ICollection<Betyg> Betygs { get; set; }
    }
}
