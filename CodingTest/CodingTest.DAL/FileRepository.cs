using CodingTest.CodingTest.Commons;
using CodingTest.CodingTest.Contracts;
using CodingTest.CodingTest.Contracts.Entites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodingTest.CodingTest.DAL
{
    public class FileRepository<T> : IRepository<T> where T : BaseEntity
    {
       
        public async Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await ReadFile();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<T>> ReadFile()
        {
            using (var stream = File.Open(@$"{FileConfiguration.BASEPATH}\{FileConfiguration.FILENAME}", FileMode.Open))
            {
                StreamReader reader = new StreamReader(stream);
                string content = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }
        }
    }
}
