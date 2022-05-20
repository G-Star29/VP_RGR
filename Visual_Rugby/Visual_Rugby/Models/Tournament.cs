using System;
using System.Collections.Generic;

namespace Visual_Rugby.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            Matches = new HashSet<Match>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long? NumberOfGames { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
