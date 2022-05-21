using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Tournament
    {
        public Tournament()
        {
            Matches = new HashSet<Match>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Time { get; set; }
        public long? PlaceId { get; set; }

        public virtual Place? Place { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
