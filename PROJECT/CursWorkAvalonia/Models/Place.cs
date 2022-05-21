using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Place
    {
        public Place()
        {
            Tournaments = new HashSet<Tournament>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
