using System;
using System.Collections.Generic;

namespace Visual_Rugby.Models
{
    public partial class Country
    {
        public Country()
        {
            Staduims = new HashSet<Staduim>();
            Teams = new HashSet<Team>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Staduim> Staduims { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
