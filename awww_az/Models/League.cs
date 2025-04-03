using awww_az.Models;
using System.Collections.Generic;

namespace awww_az.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Level { get; set; }

        // Relacja 1 (League) -> * (Team)
        public virtual ICollection<Team> Teams { get; set; }

        public League()
        {
            Teams = new HashSet<Team>();
        }
    }
}
