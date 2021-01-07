using System.Collections.Generic;
using System.Threading.Tasks;
using MyNewLanguage.Models;

namespace MyNewLanguage.Services.Interfaces
{
    public interface IDeckRepository
    {
        Task RegisterDeckAsync(Deck deck);
         Task UpdateDeckAsync(Deck deck);
         Task DeleteDeckAsync(int id);
         Task DeleteAllDecksAsync(int userId);
         Task<List<Deck>> GetAllDecks();
         Task<Deck> GetById(int id);
         Task<List<Deck>> GetByUserId(int userId);
    }
}