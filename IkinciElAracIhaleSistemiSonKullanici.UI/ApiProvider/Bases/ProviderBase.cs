using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using Newtonsoft.Json;
using System.Net.Http;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider
{
	public class ProviderBase<T> where T: class
	{
		HttpClient _httpClient;

		public ProviderBase(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<T> ProviderBaseGetAsync(string uriPath)
		{
			T test = null;
			var responseMessage = await _httpClient.GetAsync(uriPath);
			if (responseMessage.IsSuccessStatusCode)
			{
				test = JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
			}
			return test;
		}
		public async Task<List<T>> ProviderBaseListGetAsync(string uriPath)
		{
			List<T> test = null;
			var responseMessage = await _httpClient.GetAsync(uriPath);
			if (responseMessage.IsSuccessStatusCode)
			{
				test = JsonConvert.DeserializeObject<List<T>>(await responseMessage.Content.ReadAsStringAsync());
			}
			return test;
		}
	}
}
