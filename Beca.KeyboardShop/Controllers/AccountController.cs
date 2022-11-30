using AutoMapper;
using Beca.KeyboardShop.Models.Repositories;
using Beca.KeyboardShop.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity;
using Beca.KeyboardShop.Entities;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Beca.KeyboardShop.Controllers
{
    [Route("api/account/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IKeyboardShopRepository _keyboardShopRepository;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;


        // Dependency Injection
        public AccountController(IKeyboardShopRepository repository,
            ILogger<AccountController> logger, IMapper mapper)
        {
            _keyboardShopRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateToken(AccountDto accountDto)
        {
            var hasher = new PasswordHasher<User>();
            if (accountDto.Name == "Test" && accountDto.Password == "Test123!")
            {
                var user = new UserDto()
                {
                    Token = hasher.HashPassword(null, accountDto.Password),
                    Expiration = DateTime.Today.AddDays(1)
                };
                Console.WriteLine("Token creado");
                return Ok(user);
            }
            Console.WriteLine("Error AccountController, Name: " + accountDto.Name);
            return BadRequest();
        }



        //[HttpPost]
        //public async Task<ActionResult<UserDto>> CreateToken(AccountDto accountDto)
        //{
        //    var user = await _userManager.FindByNameAsync(accountDto.Name);
        //    if(user != null) 
        //    {
        //        var result = await _signInManager.CheckPasswordSignInAsync(user, accountDto.Password, false);
        //        if(result.Succeeded)
        //        {
        //            var claims = new[]
        //            {
        //                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
        //            };

        //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

        //            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //            var token = new JwtSecurityToken(
        //              _config["Tokens:Issuer"],
        //              _config["Tokens:Audience"],
        //              claims,
        //              expires: DateTime.UtcNow.AddMinutes(30),
        //              signingCredentials: creds);

        //            var results = new
        //            {
        //                token = new JwtSecurityTokenHandler().WriteToken(token),
        //                expiration = token.ValidTo
        //            };

        //            Console.WriteLine("Token creado");

        //            return Created("", results);
        //        }
        //    }
        //    return BadRequest();
        //}


    }
}