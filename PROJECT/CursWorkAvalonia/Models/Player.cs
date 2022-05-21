using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Player
    {
        public Player()
        {
            MatchPlayer1s = new HashSet<Match>();
            MatchPlayer2s = new HashSet<Match>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long? Age { get; set; }
        public long? CountryId { get; set; }
        public long? GenderId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual ICollection<Match> MatchPlayer1s { get; set; }
        public virtual ICollection<Match> MatchPlayer2s { get; set; }
    }
}
