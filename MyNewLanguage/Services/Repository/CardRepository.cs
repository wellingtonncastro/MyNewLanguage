using System.Threading.Tasks;
using MyNewLanguage.Data;
using MyNewLanguage.Models;
using Microsoft.EntityFrameworkCore;
using MyNewLanguage.Services.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Data;

namespace MyNewLanguage.Services.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly DataContext _context;
        
        public CardRepository(DataContext context)
        {
            _context = context;
            
        }
        public async Task RegisterCardAsync(Card card)
        {
            try
            {   
                var deck  =  await _context.Decks.AsNoTracking().FirstOrDefaultAsync(deck => deck.Id == card.DeckId);
                deck.Total += 1;
                deck.NewCards += 1;
                _context.Decks.Update(deck);
                
                card.TimeWait = DateTime.Now;
                card.AmountDays = 0;
                card.IsNew = true;
                _context.Cards.Add(card);
                await _context.SaveChangesAsync();   
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }

        public async Task UpdateCardAsync(Card card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteCardAsync(int id)
        {
            try
            {
                var card = await _context.Cards.FirstOrDefaultAsync(obj => obj.Id == id);
                var deck  =  await _context.Decks.AsNoTracking().FirstOrDefaultAsync(deck => deck.Id == card.DeckId);
                   
                if(card.IsNew)
                {
                    deck.NewCards -= 1;
                }

                deck.Total -= 1;
                _context.Decks.Update(deck);
                _context.Cards.Remove(card);
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }

        public async Task DeleteAllCardsAsync(int deckId)
        {
            try
            {
                var cards = await GetAllCards(deckId);
                _context.Cards.RemoveRange(cards);
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }

        public async Task UpdateOnDate(Card card)
        {
            DateTime dateToday = DateTime.Now;
            
            card.TimeWait = dateToday.AddDays(card.AmountDays);
            
            if(card.IsNew)
            {
                var deck  =  await _context.Decks.FirstOrDefaultAsync(deck => deck.Id == card.DeckId);
                
                deck.NewCards -= 1;
                card.IsNew = false;
                card.OptionAnswer = 0;

                _context.Decks.Update(deck);
                
            }
            await UpdateCardAsync(card); 
        }

        public async Task UpdateOnDateWrongOption(Card card)
        {
            DateTime dateToday = DateTime.Now;
            card.TimeWait = dateToday;
            card.OptionAnswer = 0;

            await UpdateCardAsync(card);
        }

        public async Task<List<Card>> GetAllCards(int id)
        {
            return await _context.Cards.Where(card => card.DeckId == id).ToListAsync();
        }
        public async Task<Card> GetCardByIdAsync(int deckId,int? id)
        {
            return await _context.Cards.AsNoTracking().FirstOrDefaultAsync(card => card.Id == id && card.DeckId == deckId);
        }

        public async Task<Card> GetCardByDoubt(string doubt)
        {
            return await _context.Cards.AsNoTracking().FirstOrDefaultAsync(card => card.Doubt == doubt);
        }

        public async Task<Card> GetCardByAnswer(string answer)
        {
            return await _context.Cards.AsNoTracking().FirstOrDefaultAsync(card => card.Answer == answer);
        }

        public async Task<List<Card>> GetAllInLate(int deckId)
        {
            return await _context.Cards.Where(card => card.TimeWait.Day <= DateTime.Now.Day 
                                                                && card.TimeWait.Month <= DateTime.Now.Month 
                                                                && card.TimeWait.Year <= DateTime.Now.Year )
                    .Where(card => card.DeckId == deckId).OrderByDescending(Card => Card.AmountDays).ToListAsync();
        }

        public async Task<int> GetAmountToReview(int deckId)
        {
            var cards = await GetAllInLate(deckId);
            return cards.Count;
          
        }
        private async Task<Deck> GetDeckById(int id)
        {
            return await _context.Decks.AsNoTracking().FirstOrDefaultAsync(deck => deck.Id == id);
        }
    }
}