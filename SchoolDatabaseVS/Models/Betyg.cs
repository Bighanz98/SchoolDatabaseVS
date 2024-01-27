using System;
using System.Collections.Generic;

namespace SchoolDatabaseVS.Models
{
    public partial class Betyg
    {
        public int BetygId { get; set; }
        public string? Betyg1 { get; set; }
        public int? PersonalId { get; set; }
        public int? StudentId { get; set; }
        public int? KursId { get; set; }
        public DateTime? Datum { get; set; }

        public virtual Personal? Personal { get; set; }
    }
}
