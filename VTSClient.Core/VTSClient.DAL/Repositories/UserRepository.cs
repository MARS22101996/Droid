using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VTSClient.DAL.Entities;
using VTSClient.DAL.Infrastructure;
using VTSClient.DAL.Interfaces;

namespace VTSClient.DAL.Repositories
{
	public class UserRepository : IUserRepository
	{
		private const string TokenHeaderName = "token";

		private readonly HttpClient _httpClient;

		public UserRepository()
		{
			_httpClient = new HttpClient { BaseAddress = new Uri(UrlName.GetAccountUrl()) };
		}

		public async Task<string> Login(User user)
		{
			var loginJson = JsonConvert.SerializeObject(user);

			var content = new StringContent(loginJson, Encoding.UTF8, "application/json");

			var request = new HttpRequestMessage()
			{
				RequestUri = new Uri(UrlName.GetAccountUrl()),
				Method = HttpMethod.Post,
				Content = content
			};

			var response =  _httpClient.SendAsync(request).Result;

			IEnumerable<string> headerValues;

			var isTokenExist = response.Headers.TryGetValues(TokenHeaderName, out headerValues);

			string token = null;

			if (isTokenExist)
			{
				token = headerValues.FirstOrDefault();
			}

			return token;
		}
	}
}
