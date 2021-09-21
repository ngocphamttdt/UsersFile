using CodingTest.CodingTest.Contracts.DTOs;
using CodingTest.CodingTest.Contracts.Entites;
using CodingTest.CodingTest.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)=> _userService = userService;
        
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get() => await _userService.GetUserAsync();

        [HttpPost]
        public async Task<bool> Post([FromBody]UserDto user) => await _userService.AddUserAsync(user);
        
    }
}