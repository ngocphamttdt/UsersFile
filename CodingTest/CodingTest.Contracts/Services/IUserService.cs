using CodingTest.CodingTest.Contracts.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.CodingTest.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUser();
    }
}
