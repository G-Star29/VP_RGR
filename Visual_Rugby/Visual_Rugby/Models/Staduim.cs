using System;
using System.Collections.Generic;

namespace Visual_Rugby.Models
{
    public partial class Staduim
    {
        public Staduim()
        {
            Matches = new HashSet<Match>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long? CountryId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
