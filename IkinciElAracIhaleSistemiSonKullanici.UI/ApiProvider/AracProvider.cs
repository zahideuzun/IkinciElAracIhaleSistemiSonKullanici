using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.AracOzellikDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using Newtonsoft.Json;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider
{
	public class AracProvider
	{
		HttpClient _httpClient;

		public AracProvider(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<OzellikDetayDTO>?> IhaledekiAracOzellikleriniGetir(int id)
		{
			List<OzellikDetayDTO>? listem = null;
			var responseMessage = await _httpClient.GetAsync($"Arac/AracDetay/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				listem = JsonConvert.DeserializeObject<List<OzellikDetayDTO>>(await responseMessage.Content.ReadAsStringAsync());
			}

			return listem;
		}

		public async Task<AracIhaleDTO?> AracIdyeGoreAracIhaleFiyatiniGetir(int aracId)
		{
			ProviderBase<AracIhaleDTO> ihale = new ProviderBase<AracIhaleDTO>(_httpClient);

			return await ihale.ProviderBaseGetAsync($"Arac/AracIhaleFiyat/{aracId}");
		}

	}
}
