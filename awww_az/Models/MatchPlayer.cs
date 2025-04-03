using awww_az.Models;
using System;

namespace awww_az.Models
{
    public class MatchPlayer
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Klucz obcy do Match
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        // Klucz obcy do Player
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
