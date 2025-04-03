using awww_az.Models;
using System;
using System.Collections.Generic;

namespace awww_az.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }

        // Relacja 1 (Match) -> * (MatchEvent)
        public virtual ICollection<MatchEvent> MatchEvents { get; set; }

        // Relacja 1 (Match) -> * (MatchPlayer)
        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; }

        public Match()
        {
            MatchEvents = new HashSet<MatchEvent>();
            MatchPlayers = new HashSet<MatchPlayer>();
        }
    }
}
