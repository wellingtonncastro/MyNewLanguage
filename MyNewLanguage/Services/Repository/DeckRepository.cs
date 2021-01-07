using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNewLanguage.Data;
using MyNewLanguage.Models;
using MyNewLanguage.Services.Interfaces;

namespace MyNewLanguage.Services.Repository
{
    public class DeckRepository : IDeckRepository
    {
        private readonly DataContext _context;
        public DeckRepository(DataContext context)
        {
            _context = context;
        }

        
        public async Task RegisterDeckAsync(Deck deck)
        {
            _context.Decks.Add(deck);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDeckAsync(Deck deck)
        {
            _context.Decks.Update(deck);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDeckAsync(int id)
        {
            try
            {
                var deck = await _context.Decks.FirstOrDefaultAsync(obj => obj.Id == id);

                _context.Decks.Remove(deck);
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }
        
        public async Task DeleteAllDecksAsync(int userId)
        {
            try
            {
                var decks = await GetByUserId(userId);
                
                _context.Decks.RemoveRange(decks);
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }

        public async Task<List<Deck>> GetAllDecks()
        {
            return await _context.Decks.ToListAsync();
        }

        public async Task<Deck> GetById(int id)
        {
            return await _context.Decks.AsNoTracking().Where(deck => deck.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Deck>> GetByUserId(int userId)
        {
            return await _context.Decks.AsNoTracking().Where(deck => deck.UserId == userId).ToListAsync();
        }

    }
}