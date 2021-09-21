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
        public async Task<bool> AddAsync(T entity)
        {
            IList<T> data = (await ReadFile()).ToList();

            entity.Id = (await GetMaxId(data)) + 1;
            data.Add(entity);

            string convertedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            return await WriteFile(convertedJson);
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

        private async Task<bool> WriteFile(string jsonData)
        {
            try
            {
                File.WriteAllText(@$"{FileConfiguration.BASEPATH}\{FileConfiguration.FILENAME}", String.Empty);

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(@$"{FileConfiguration.BASEPATH}\{FileConfiguration.FILENAME}"), true))
                {
                    await outputFile.WriteAsync(jsonData);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }
        private async Task<int> GetMaxId(IEnumerable<T> users) => (await ReadFile()).Max(x => x.Id);
    }
}
