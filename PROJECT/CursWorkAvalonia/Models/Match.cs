using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Match
    {
        public long Id { get; set; }
        public long? Player1Id { get; set; }
        public long? Player2Id { get; set; }
        public long? Score1 { get; set; }
        public long? Score2 { get; set; }
        public long? TournamentId { get; set; }

        public virtual Player? Player1 { get; set; }
        public virtual Player? Player2 { get; set; }
        public virtual Tournament? Tournament { get; set; }
    }
}
