using System;
using System.Collections.Generic;

namespace Visual_Rugby.Models
{
    public partial class Team
    {
        public Team()
        {
            MatchTeam0Navigations = new HashSet<Match>();
            MatchTeam1Navigations = new HashSet<Match>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long? NumberOfPlayers { get; set; }
        public long? Games { get; set; }
        public long? Age { get; set; }
        public long? CountryId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<Match> MatchTeam0Navigations { get; set; }
        public virtual ICollection<Match> MatchTeam1Navigations { get; set; }
    }
}
