using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNewLanguage.Services.Interfaces;

namespace MyNewLanguage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;
        public StatisticController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("{DeckId}")]
        [Route("GetByDeck/{DeckId}")]
        public async Task<IActionResult> Get(int DeckId)
        {
            try
            {
                return Ok(await _statisticRepository.GetStatisticByDeckIdAsync(DeckId));
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}