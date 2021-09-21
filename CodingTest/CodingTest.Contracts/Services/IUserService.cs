using CodingTest.CodingTest.Contracts.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingTest.CodingTest.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUserAsync();
        Task<bool> AddUserAsync(UserDto user);
    }
}
