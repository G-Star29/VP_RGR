using System;
using System.Collections.Generic;

namespace Visual_Rugby.Models
{
    public partial class Result
    {
        public Result()
        {
            Matches = new HashSet<Match>();
        }

        public long Id { get; set; }
        public long? Score0 { get; set; }
        public long? Score1 { get; set; }
        public string? Date { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
