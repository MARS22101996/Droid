using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VTSClient.DAL.Infrastructure;
using VTSClient.DAL.Interfaces;

namespace VTSClient.DAL.Repositories
{
    public class CommonApiRepository : IApiRepository
    { 
        private HttpClient _httpClient;

        public CommonApiRepository()
        {
            _httpClient = new HttpClient {BaseAddress = new Uri(UrlName.GetApiUrl())};
        }

        public async Task<IEnumerable<T>> GetAsync<T>(string url)
        {
            var contentJObject = await GetRequestAsync(url);

            var entities = contentJObject["listResult"].ToObject<IEnumerable<T>>();

            return entities;
        }

        public async Task<T> GetByIdAsync<T>(Guid id, string url)
        {
            var uri = $"{url}/{id}";

            var contentJObject = await GetRequestAsync(uri);

            var entity = contentJObject["itemResult"].ToObject<T>();

            return entity;
        }


        private async Task<JObject> GetRequestAsync(string uri)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            var contentJObject = JObject.Parse(content);

            return contentJObject;
        }


        public Task<bool> CreateAsync<T>(T entity, string url)
        {
            return CreateOrUpdateAsync(entity, HttpMethod.Put, url);
        }

        public Task<bool> UpdateAsync <T>(T entity, string url)
        {
            return CreateOrUpdateAsync(entity, HttpMethod.Put, url);
        }

        public async Task<bool> DeleteAsync <T>(Guid id, string url)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri($"{url}/{id}"),
                Method = HttpMethod.Delete
            };

            var response = await _httpClient.SendAsync(request);

            return await IsRequestSucceed(response);
        }

        public async Task<bool> CreateOrUpdateAsync <T>(T entity, HttpMethod httpMethod, string url)
        {
            var entityJson = JsonConvert.SerializeObject(entity);

            var content = new StringContent(entityJson);

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Post,
                Content = content
            };

            var response = await _httpClient.SendAsync(request);

            return await IsRequestSucceed(response);
        }

        private async Task<bool> IsRequestSucceed(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            var result = JObject.Parse(content).SelectToken(@"$.resultCode").ToString();

            var resultCode = Convert.ToInt16(result);

            return resultCode == 0;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_httpClient == null) return;
            _httpClient.Dispose();
            _httpClient = null;
        }
    }
}
