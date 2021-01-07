using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNewLanguage.Models;
using MyNewLanguage.Services.Interfaces;

namespace MyNewLanguage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        private readonly IDeckRepository _deckRepository;
        private readonly IStatisticRepository _statisticRepository;
       
        public CardController(ICardRepository cardRepository, IDeckRepository deckRepository, IStatisticRepository statisticRepository)
        {
            _cardRepository = cardRepository;
            _deckRepository = deckRepository;
            _statisticRepository = statisticRepository;
        }

        [HttpGet("{DeckId}")]
        [Route("GetAll/{DeckId}")]
        public async Task<IActionResult> GetAll(int DeckId)
        {
            try
            {
                return Ok(await _cardRepository.GetAllCards(DeckId));
            }
            catch (Exception)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError,"DataBase is fail");
            }
        }

        [HttpGet("{CardId}")]
        [Route("GetById/{DeckId}/{CardId}")]
        public async Task<IActionResult> GetById(int DeckId ,int CardId)
        {
            try
            {
                return Ok(await _cardRepository.GetCardByIdAsync(DeckId, CardId));
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }

        
        [HttpGet("{DeckId}")]
        [Route("GetInLate/{DeckId}")]
        public async Task<IActionResult> GetInLate(int DeckId)
        {
            try
            {
                return Ok(await _cardRepository.GetAllInLate(DeckId));
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }

        [HttpGet("CardDoubt")]
        [Route("GetByDoubt/{CardDoubt}")]
        public async Task<IActionResult> GetByDoubt(string CardDoubt)
        {
            try
            {
                return Ok(await _cardRepository.GetCardByDoubt(CardDoubt));
            }
            catch (System.Exception ex)
            {   
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }

        [HttpGet("CardAnswer")]
        [Route("GetByAnswer/{CardAnswer}")]
        public async Task<IActionResult> GetByAnswer(string CardAnswer)
        {
            try
            {
                return Ok(await _cardRepository.GetCardByAnswer(CardAnswer));
            }
            catch (System.Exception ex)
            {   
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }
        
        [HttpGet("DeckId")]
        [Route("GetToReview/{DeckId}")]
        public async Task<IActionResult> GetToReview(int DeckId)
        {
            try
            {
                return Ok(await _cardRepository.GetAmountToReview(DeckId));
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Card card)
        {
            try
            {
                await _cardRepository.RegisterCardAsync(card);
                
                return Created($"/api/card/{card.Id}",card);
            }
            catch (System.Exception ex)
            {   
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPut("{CardId}")]
        public async Task<IActionResult> Put(int CardId,Card card)
        {
            try
            {
                var cardFromBase = await _cardRepository.GetCardByIdAsync(card.DeckId,CardId);

                if(cardFromBase == null || cardFromBase.Id != card.Id || cardFromBase.DeckId != card.DeckId)
                {
                    return NotFound();
                }

                DateTime dateToday = DateTime.Now;
               
                var deckFromBase = await _deckRepository.GetById(card.DeckId);
                var statistic = await _statisticRepository.GetStatisticByDeckIdAsync(deckFromBase.Id);

                if(card.OptionAnswer == 0)
                {
                    await _cardRepository.UpdateCardAsync(card);
                }

                else if(card.OptionAnswer == 1)
                {
                    statistic.TotalWrongWeek +=1;
                    
                    switch(dateToday.Month)
                        {
                            case 1:
                                statistic.TotalWrongJanuary += 1;
                            break;
                            case 2:
                                statistic.TotalWrongFebruary += 1;
                            break;
                            case 3:
                                statistic.TotalWrongMarch += 1;
                            break;
                            case 4:
                                statistic.TotalWrongApril += 1;
                            break;
                            case 5:
                                statistic.TotalWrongMay += 1;
                            break;
                            case 6:
                                statistic.TotalWrongJune += 1;
                            break;
                            case 7:
                                statistic.TotalWrongJuly += 1;
                            break;
                            case 8:
                                statistic.TotalWrongAugust += 1;
                            break;
                            case 9:
                                statistic.TotalWrongSeptember += 1;
                            break;
                            case 10:
                                statistic.TotalWrongOctober += 1;
                            break;
                            case 11:
                                statistic.TotalWrongNovember += 1;
                            break;
                            case 12:
                                statistic.TotalWrongDecember += 1;
                            break;
                        }

                    await _statisticRepository.UpdateStatisticAsync(statistic);
                    await _cardRepository.UpdateOnDateWrongOption(card);
                }
                else if(card.OptionAnswer == 2)
                {
                    statistic.TotalHardWeek +=1;
                        
                    switch(dateToday.Month)
                        {
                            case 1:
                                statistic.TotalHardJanuary += 1;
                            break;
                            case 2:
                                statistic.TotalHardFebruary += 1;
                            break;
                            case 3:
                                statistic.TotalHardMarch += 1;
                            break;
                            case 4:
                                statistic.TotalHardApril += 1;
                            break;
                            case 5:
                                statistic.TotalHardMay += 1;
                            break;
                            case 6:
                                statistic.TotalHardJune += 1;
                            break;
                            case 7:
                                statistic.TotalHardJuly += 1;
                            break;
                            case 8:
                                statistic.TotalHardAugust += 1;
                            break;
                            case 9:
                                statistic.TotalHardSeptember += 1;
                            break;
                            case 10:
                                statistic.TotalHardOctober += 1;
                            break;
                            case 11:
                                statistic.TotalHardNovember += 1;
                            break;
                            case 12:
                                statistic.TotalHardDecember += 1;
                            break;
                        }
                        
                    await _statisticRepository.UpdateStatisticAsync(statistic);
                    await _cardRepository.UpdateOnDate(card);  
                }
                else if(card.OptionAnswer == 3)
                {
                    statistic.TotalGoodWeek +=1;
                        
                    switch(dateToday.Month)
                        {
                            case 1:
                                statistic.TotalGoodJanuary += 1;
                            break;
                            case 2:
                                statistic.TotalGoodFebruary += 1;
                            break;
                            case 3:
                                statistic.TotalGoodMarch += 1;
                            break;
                            case 4:
                                statistic.TotalGoodApril += 1;
                            break;
                            case 5:
                                statistic.TotalGoodMay += 1;
                            break;
                            case 6:
                                statistic.TotalGoodJune += 1;
                            break;
                            case 7:
                                statistic.TotalGoodJuly += 1;
                            break;
                            case 8:
                                statistic.TotalGoodAugust += 1;
                            break;
                            case 9:
                                statistic.TotalGoodSeptember += 1;
                            break;
                            case 10:
                                statistic.TotalGoodOctober += 1;
                            break;
                            case 11:
                                statistic.TotalGoodNovember += 1;
                            break;
                            case 12:
                                statistic.TotalGoodDecember += 1;
                            break;

                        }
                        
                    await _statisticRepository.UpdateStatisticAsync(statistic);
                    await _cardRepository.UpdateOnDate(card);
                }
                else if(card.OptionAnswer == 4)
                {
                    statistic.TotalEasyWeek +=1;
                        
                    switch(dateToday.Month)
                        {
                            case 1:
                                statistic.TotalEasyJanuary += 1;
                            break;
                            case 2:
                                statistic.TotalEasyFebruary += 1;
                            break;
                            case 3:
                                statistic.TotalEasyMarch += 1;
                            break;
                            case 4:
                                statistic.TotalEasyApril += 1;
                            break;
                            case 5:
                                statistic.TotalEasyMay += 1;
                            break;
                            case 6:
                                statistic.TotalEasyJune += 1;
                            break;
                            case 7:
                                statistic.TotalEasyJuly += 1;
                            break;
                            case 8:
                                statistic.TotalEasyAugust += 1;
                            break;
                            case 9:
                                statistic.TotalEasySeptember += 1;
                            break;
                            case 10:
                                statistic.TotalEasyOctober += 1;
                            break;
                            case 11:
                                statistic.TotalEasyNovember += 1;
                            break;
                            case 12:
                                statistic.TotalEasyDecember += 1;
                            break;

                        }
                        
                    await _statisticRepository.UpdateStatisticAsync(statistic);
                    await _cardRepository.UpdateOnDate(card);   
                }
                else
                {
                   return NotFound(); 
                }

                return Created($"/api/card/{card.Id}",card);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }

        [Route("DeleteCard/{DeckId}/{CardId}")]
        public async Task<IActionResult> Delete(int DeckId,int CardId)
        {
            try
            {
                var cardFromBase = await _cardRepository.GetCardByIdAsync(DeckId,CardId);
                if(cardFromBase == null)
                {
                    return NotFound();
                }
                await _cardRepository.DeleteCardAsync(cardFromBase.Id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }
    }
}