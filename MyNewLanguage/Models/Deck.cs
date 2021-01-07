using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyNewLanguage.Models
{
    public class Deck
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [StringLength(150, MinimumLength = 4)]
        public string DeckName { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public int GoodTimeWait { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public int EasyTimeWait { get; set; }
        public int Total{get;set;}
        public int NewCards{get;set;}
        public int ReviewCards{get;set;}
        public int UserId { get; set; }

    }
}