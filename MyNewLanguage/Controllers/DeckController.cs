using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNewLanguage.Models;
using MyNewLanguage.Models.Identity;
using MyNewLanguage.Services.Interfaces;

namespace MyNewLanguage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeckController : ControllerBase
    {
        private readonly IDeckRepository _deckRepository;
        private readonly UserManager<User> _userManager;
        private readonly IStatisticRepository _statisticRepository;
        private readonly ICardRepository _cardRepository;
        public DeckController(UserManager<User> userManager, IDeckRepository deckRepository, IStatisticRepository statisticRepository, ICardRepository cardRepository)
        {
            _deckRepository = deckRepository;
            _statisticRepository = statisticRepository;
            _userManager = userManager;
            _cardRepository = cardRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _deckRepository.GetAllDecks());
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"DataBase is fail");
            }
        }

        [HttpGet("GetById/{DeckId}")]
        [Route("GetById/{DeckId}")]
        public async Task<IActionResult> Get(int DeckId)
        {
            try
            {
                return Ok(await _deckRepository.GetById(DeckId));
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status404NotFound,"DataBase is fail");
            }
        }

        [HttpGet("GetByUserId/{UserId}")]
        [Route("GetByUserId/{UserId}")]
        public async Task<IActionResult> GetByUserId(int UserId)
        {
            try
            {
                return Ok(await _deckRepository.GetByUserId(UserId));
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status404NotFound,"DataBase is fail");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Deck deck)
        {
            try
            {
                // Month month = new Month(0,0,0,0,0,0,0,0,0,0,0,0,0);
                // Week week = new Week(0,0,0,0,0);
                
                // await _weekRepository.RegisterWeekAsync(week);
                // await _monthRepository.RegisterMonthAsync(month);
                
                // deck.Week = week;
                // deck.WeekId = week.Id;
                // deck.Month = month;
                // deck.MonthId = month.Id;
               
                if(await _userManager.FindByIdAsync(deck.UserId.ToString()) == null)
                {
                    return NotFound();
                }
                
                await _deckRepository.RegisterDeckAsync(deck);

                Statistic statistic = new Statistic(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                                    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);
                statistic.Deck = deck;
                statistic.DeckId = deck.Id;
                
                await _statisticRepository.RegisterStatisticAsync(statistic);
                return Created($"/api/deck/{deck.Id}",deck);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        //[AllowAnonymous]
        [HttpPut("{DeckId}")]
        //TODO - PUT - don't work yet
        public async Task<IActionResult> Put(int DeckId,Deck deck)
        {
            try
            {
                var DeckFromBase = await _deckRepository.GetById(deck.Id);
                if(DeckFromBase == null || DeckFromBase.Id != deck.Id || DeckId != deck.Id)
                {
                    return NotFound();
                }
                
                await _deckRepository.UpdateDeckAsync(deck);
                return Created($"/api/deck/{deck.Id}",deck);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [Route("DeleteDeck/{DeckId}")]
        public async Task<IActionResult> Delete(int DeckId)
        {
            try
            {
                var deckFromBase = await _deckRepository.GetById(DeckId);
                if(deckFromBase == null)
                {
                    return NotFound();
                }

                var statisticFromBase = await _statisticRepository.GetStatisticByDeckIdAsync(deckFromBase.Id);
                if(statisticFromBase == null)
                {
                    return NotFound();
                }

                await _statisticRepository.DeleteStatisticAsync(statisticFromBase.Id, deckFromBase.Id);
                await _cardRepository.DeleteAllCardsAsync(deckFromBase.Id);
                await _deckRepository.DeleteDeckAsync(deckFromBase.Id);
                
                return Ok();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

    }
}