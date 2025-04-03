using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace awww_az.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa drużyny jest wymagana")]
        [StringLength(100, ErrorMessage = "Nazwa drużyny nie może przekraczać 100 znaków")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Miasto jest wymagane")]
        [StringLength(100, ErrorMessage = "Nazwa miasta nie może przekraczać 100 znaków")]
        public string City { get; set; }

        [Required(ErrorMessage = "Data założenia jest wymagana")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FoundingDate { get; set; }

        // Klucz obcy do League
        [Required(ErrorMessage = "Liga jest wymagana")]
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