using awww_az.Models;
using System;

namespace awww_az.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public DateTime EventDateTime { get; set; }

        // Klucz obcy do Match
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        // Klucz obcy do EventType
        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }
    }
}

