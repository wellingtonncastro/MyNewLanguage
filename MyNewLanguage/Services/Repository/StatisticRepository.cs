using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNewLanguage.Data;
using MyNewLanguage.Models;
using MyNewLanguage.Services.Interfaces;

namespace MyNewLanguage.Services.Repository
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly DataContext _context;
        public StatisticRepository(DataContext context)
        {
            _context = context;
        }

        public async Task RegisterStatisticAsync(Statistic statistic )
        {
            _context.Statistics.Add(statistic);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatisticAsync(Statistic statistic)
        {
            _context.Statistics.Update(statistic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStatisticAsync(int statisticId, int deckId)
        {
            try
            {
                var statistic = await GetStatisticByIdAndByDeckIdAsync(statisticId,deckId);
                _context.Statistics.Remove(statistic);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }

        public async Task<Statistic> GetStatisticByIdAndByDeckIdAsync(int statisticId, int deckId)
        {
            return await _context.Statistics.Where(st => st.Id == statisticId && st.DeckId == deckId).FirstOrDefaultAsync();
        }

        public async Task<Statistic> GetStatisticByDeckIdAsync(int deckId)
        {
            return await _context.Statistics.Where(st => st.DeckId == deckId).FirstOrDefaultAsync();
        }
    }
}