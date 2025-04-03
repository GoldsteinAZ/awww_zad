using awww_az.Models;
using System;
using System.Collections.Generic;

namespace awww_az.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime FoundingDate { get; set; }

        // Klucz obcy do League
        public int LeagueId { get; set; }
        public virtual League League { get; set; }

        // Relacja 1 (Team) -> * (Player)
        public virtual ICollection<Player> Players { get; set; }

        public Team()
        {
            Players = new HashSet<Player>();
        }
    }
}
