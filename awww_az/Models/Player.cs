using awww_az.Models;
using System;
using System.Collections.Generic;

namespace awww_az.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }

        // Klucz obcy do Team
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        // Klucz obcy do Position
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        // Relacja 1 (Player) -> * (MatchPlayer)
        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; }

        public Player()
        {
            MatchPlayers = new HashSet<MatchPlayer>();
        }
    }
}
