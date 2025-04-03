using awww_az.Models;
using System.Collections.Generic;

namespace awww_az.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relacja 1 (EventType) -> * (MatchEvent)
        public virtual ICollection<MatchEvent> MatchEvents { get; set; }

        public EventType()
        {
            MatchEvents = new HashSet<MatchEvent>();
        }
    }
}

