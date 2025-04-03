using awww_az.Models;
using System.Collections.Generic;

namespace awww_az.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relacja 1 (Position) -> * (Player)
        public virtual ICollection<Player> Players { get; set; }

        public Position()
        {
            Players = new HashSet<Player>();
        }
    }
}

