using System;
using System.Linq;
using MyNewLanguage.Models;

namespace MyNewLanguage.Data
{
    public class SeedingServices
    {
        private DataContext _context;

        public SeedingServices(DataContext context)
        {
            _context = context;
        }
        //TODO - antes de rodar, colocar a quantidade de cartas no deck primeiro
        public void Seed()
        {
            if(_context.Cards.Any())
            {
                return;
            }
            else
            {
                DateTime date1 = new DateTime(2020,12,12);
                DateTime date2 = new DateTime(2021,05,04);

                
                Deck deck = new Deck();
                deck.Id= 1 ;
                deck.DeckName = "Personal deck";
                deck.Total = 2;
                deck.ReviewCards = 0;
                deck.NewCards = 2;
                deck.GoodTimeWait = 1;
                deck.EasyTimeWait = 2;
                deck.UserId = 0;
                Statistic statistic = new Statistic(12,45,75,4,2,4,572,75,7,2,7,2,7,5,152,7,78,22,42,42,14,5,0,45,6,
                                                        45,12,45,45,7,5,2,45,45,8,7,54,78,32,45,78,45,8,65,7,99,56,45,456,
                                                        34,54,67,2);
                statistic.Id = 1;
                statistic.Deck = deck;
                statistic.DeckId = deck.Id;

                
                Card card1 = new Card();
                card1.Id = 1;
                card1.Doubt= "Did you see that?";
                card1.Answer = "Você viu aquilo";
                card1.Note=null;
                card1.Deck = deck;
                card1.DeckId = deck.Id;
                card1.TimeWait = date1;
                card1.AmountDays = 0;

                Card card2 = new Card();
                card2.Id = 2;
                card2.Doubt = "I watched the sunset";
                card2.Answer = "Eu assisti o por-do-sol";
                card2.Note = "watched = passado";
                card2.Deck = deck;
                card2.DeckId = deck.Id;
                card2.TimeWait = date2;
                card2.AmountDays = 0;
                
                _context.Statistics.Add(statistic);
                _context.Decks.Add(deck);
                _context.Cards.AddRange(card1,card2);

                _context.SaveChanges();
            }
        }
    }
}