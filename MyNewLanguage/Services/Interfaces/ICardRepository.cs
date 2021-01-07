using System.Collections.Generic;
using System.Threading.Tasks;
using MyNewLanguage.Models;

namespace MyNewLanguage.Services.Interfaces
{
    public interface ICardRepository
    {
         Task RegisterCardAsync(Card card);
         Task UpdateCardAsync(Card card);
         Task DeleteCardAsync(int id);
         Task DeleteAllCardsAsync(int deckId);
         Task UpdateOnDate(Card card);
         Task UpdateOnDateWrongOption(Card card);
         Task<List<Card>> GetAllCards(int id);
         Task<Card> GetCardByIdAsync(int deckId,int? id);
         Task<Card> GetCardByDoubt(string doubt);
         Task<Card> GetCardByAnswer(string answer);
         Task<List<Card>> GetAllInLate(int deckId);
         Task<int> GetAmountToReview(int deckId);

    }
}