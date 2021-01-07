using System.Threading.Tasks;
using MyNewLanguage.Models;

namespace MyNewLanguage.Services.Interfaces
{
    public interface IStatisticRepository
    {
         Task RegisterStatisticAsync(Statistic statistic);
         Task UpdateStatisticAsync(Statistic statistic);
         Task DeleteStatisticAsync(int statisticId, int deckId);
         Task<Statistic> GetStatisticByIdAndByDeckIdAsync(int statisticId, int deckId);
         Task<Statistic> GetStatisticByDeckIdAsync(int deckId);
    }
}