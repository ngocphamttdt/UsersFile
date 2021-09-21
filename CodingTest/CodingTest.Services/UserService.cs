using CodingTest.CodingTest.Contracts;
using CodingTest.CodingTest.Contracts.DTOs;
using CodingTest.CodingTest.Contracts.Entites;
using CodingTest.CodingTest.Contracts.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.CodingTest.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        public UserService(IRepository<User> repository)=> _repository = repository;
        
        public async Task<IEnumerable<UserDto>> GetUserAsync()
        {
            return (await _repository.GetAsync()).Select(a => new UserDto
            {
                FirstName = a.FirstName,
                LastName = a.LastName
            });
        }

        public async Task<bool> AddUserAsync(UserDto user)
        {
            return await _repository.AddAsync(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            });
        }
    }
}
