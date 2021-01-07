using System;
using System.ComponentModel.DataAnnotations;

namespace MyNewLanguage.Models
{
    public class Card
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [StringLength(256, MinimumLength = 4)]
        public string Doubt { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(256, MinimumLength = 4)]
        public string Answer { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, MinimumLength = 4)]
        public string Note { get; set; }
        
        public DateTime TimeWait { get; set; }
        public int AmountDays { get; set; }
        public Deck Deck{get;set;}
        public int DeckId{get;set;}
        public int OptionAnswer{get;set;}
        public bool IsNew{get;set;}
    }
}