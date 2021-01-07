using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyNewLanguage.Dtos;
using MyNewLanguage.Models.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;
using MyNewLanguage.Services.Interfaces;

namespace MyNewLanguage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IDeckRepository _deckRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IStatisticRepository _statisticRepository;

        private readonly IMapper _mapper;

        public UserController(IDeckRepository deckRepository, ICardRepository cardRepository, 
                                IStatisticRepository statisticRepository, IConfiguration config, 
                                UserManager<User> userManager,
                                SignInManager<User> signInManager, IMapper mapper)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _cardRepository = cardRepository;
            _deckRepository = deckRepository;
            _statisticRepository = statisticRepository;
        }
        
        [HttpGet("GetUser")]
        public IActionResult GetUser(UserDto userDto)
        {
            return Ok(userDto);
        }

        [HttpGet("{UserId}")]
        [Route("GetUserById/{CompareId}/{UserId}")]
        public async Task<IActionResult> GetUserById( int CompareId, int UserId)
        {
            string token = Request.Headers["Authorization"];
            token = token.Replace("Bearer ", "");
            if(CompareId == UserId)
            {
                var result = await _userManager.FindByIdAsync(UserId.ToString());
                if(result == null)
                {
                    return NotFound();        
                }
                
                if(!result.JsonWebToken.Equals(token))
                {
                    return Unauthorized();
                }

                var user = _mapper.Map<UserDto>(result);
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.PasswordHash);

                if(result.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserDto>(user);
                    return Created("GetUser", userToReturn);
                }

                return BadRequest(result.Errors);
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }

        [HttpPut("{UserId}")]
        public async Task<IActionResult> Put(int UserId, UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                
                if(UserId != user.Id )
                {
                    return BadRequest();
                }

                var userFromBase = await _userManager.FindByIdAsync(UserId.ToString());

                if(userFromBase == null)
                {
                    return NotFound();
                }

                userFromBase.Email = user.Email;
                userFromBase.FullName = user.FullName;
                userFromBase.UserName = user.UserName;

                var result = await _userManager.UpdateAsync(userFromBase);

                if(result.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserDto>(user);
                    return Created("GetUser", userToReturn);
                }

                return BadRequest();

            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }

        [HttpPut("{UserId}")]
        [Route("ChangePassword/{UserId}")]
        public async Task<IActionResult> ChangePassword(int UserId, UserToChangePasswordDto userDto)
        {
            try
            {
                if(userDto == null)
                {
                    return BadRequest();
                }

                var userFromBase = await _userManager.FindByIdAsync(UserId.ToString());
                
                if(userFromBase == null)
                {
                    return NotFound();
                }

                string token = Request.Headers["Authorization"];
                token = token.Replace("Bearer ", "");

                var result = await _signInManager.CheckPasswordSignInAsync(userFromBase, userDto.PasswordHash,false);

                if(!userFromBase.JsonWebToken.Equals(token) || !result.Succeeded)
                {
                    return Unauthorized();
                }
                
                var resultFromChage = await _userManager.ChangePasswordAsync(userFromBase, userFromBase.PasswordHash, userDto.NewPasswordHash);
                
                // if(resultFromChage.Succeeded)
                // {
                await _signInManager.RefreshSignInAsync(userFromBase);
                var userToReturn = _mapper.Map<UserDto>(userFromBase);
                return Created("GetUser", userToReturn);
               

                //}
                    

                //return BadRequest();
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }

        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> Delete(int UserId)
        {
            //TESTAR DEPOIS
            try
            {
                var user = await _userManager.FindByIdAsync(UserId.ToString());
                
                if(user == null)
                {
                   return NotFound();
                }

                string token = Request.Headers["Authorization"];
                token = token.Replace("Bearer ", "");

                if(!user.JsonWebToken.Equals(token))
                {
                    return Unauthorized();
                }
                var decks = await _deckRepository.GetByUserId(user.Id);
                
                foreach(var deck in decks)
                {
                    var statistic = await _statisticRepository.GetStatisticByDeckIdAsync(deck.Id);

                    await _cardRepository.DeleteAllCardsAsync(deck.Id);
                    await _statisticRepository.DeleteStatisticAsync(statistic.Id, deck.Id);
                }
                
                await _deckRepository.DeleteAllDecksAsync(user.Id);
                await _userManager.DeleteAsync(user);

                return Ok(); 
                
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
                
                var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.PasswordHash,false);

                if(result.Succeeded)
                {
                    
                    var appUser = await _userManager.Users.FirstOrDefaultAsync(u => 
                                         u.NormalizedUserName == userLoginDto.UserName.ToUpper());

                   
                    var userToReturn = _mapper.Map<UserDto>(appUser);
                    
                    var token = GenerateJWTToken(appUser).Result;
                    user.JsonWebToken = token;

                    await _userManager.UpdateAsync(appUser);
                    return Ok(new {
                        token,
                        user = userToReturn
                    });

                    
                }

                return Unauthorized();

                
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"DataBase is fail {ex.Message}");
            }
        }

        private async Task<string> GenerateJWTToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("AppSettings:Secret");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            
            var roles = await _userManager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}