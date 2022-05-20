using System;
using System.Collections.Generic;

namespace Visual_Rugby.Models
{
    public partial class Match
    {
        public long Id { get; set; }
        public long? Team0 { get; set; }
        public long? Team1 { get; set; }
        public long? TournamentId { get; set; }
        public long? StaduimId { get; set; }
        public long? ResultId { get; set; }

        public virtual Result? Result { get; set; }
        public virtual Staduim? Staduim { get; set; }
        public virtual Team? Team0Navigation { get; set; }
        public virtual Team? Team1Navigation { get; set; }
        public virtual Tournament? Tournament { get; set; }
    }
}
