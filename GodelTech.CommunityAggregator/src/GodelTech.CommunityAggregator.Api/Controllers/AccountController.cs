using AutoMapper;
using GodelTech.CommunityAggregator.Api.Helpers;
using GodelTech.CommunityAggregator.Api.Models;
using GodelTech.CommunityAggregator.Bll.Dto;
using GodelTech.CommunityAggregator.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GodelTech.CommunityAggregator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IMapper mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            this.accountService = accountService;
            this.mapper = mapper;
        }

        [HttpPost("/token")]
        public IActionResult GetToken([FromBody]LoginView value)
        {
            var username = value.Login;
            var password = value.Password;

            var identity = accountService.GetIndentity(username, password);
            if (identity == null)
            {
                return BadRequest("Invalid username or password.");
            }

            return Ok(JwtTokenHelper.GetJwtToken(identity, value.Login));
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]LoginView value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid username or password.");
            }

            var user = mapper.Map<LoginView, UserDto>(value);
            user.Role = "user";
            accountService.CreateUser(user);

            return Ok("Account has been created");

        }
    }
}
