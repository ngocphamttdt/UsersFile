using CodingTest.CodingTest.Contracts;
using CodingTest.CodingTest.Contracts.Entites;
using CodingTest.CodingTest.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.CodingTest.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _repository.GetAsync();
        }
    }
}
