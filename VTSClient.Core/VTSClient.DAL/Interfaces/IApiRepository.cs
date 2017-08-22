using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace VTSClient.DAL.Interfaces
{
    public interface IApiRepository
    {
        Task<IEnumerable<T>> GetAsync<T>(string url);

        Task<T> GetByIdAsync<T>(Guid id, string url);

        Task<bool> CreateAsync<T>(T entity, string url);

        Task<bool> UpdateAsync<T>(T entity, string url);

        Task<bool> DeleteAsync<T>(Guid id, string url);

        Task<bool> CreateOrUpdateAsync<T>(T entity, HttpMethod httpMethod, string url);
    }
}
