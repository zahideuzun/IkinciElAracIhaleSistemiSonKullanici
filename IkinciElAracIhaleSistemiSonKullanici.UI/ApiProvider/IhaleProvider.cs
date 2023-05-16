using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using Newtonsoft.Json;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider
{
    public class IhaleProvider
    {
        HttpClient _httpClient;

        public IhaleProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<IhaleBilgisiDTO>?> IhaleListesiniGetir()
        {
	        //ProviderBase<List<IhaleBilgisiDTO>> ihale = new ProviderBase<List<IhaleBilgisiDTO>>(_httpClient);

	        //return await ihale.ProviderBaseListGetAsync("Ihale/Index");

			List<IhaleBilgisiDTO>? listem = null;
            var responseMessage = await _httpClient.GetAsync("Ihale/Index");
            if (responseMessage.IsSuccessStatusCode)
            {
                listem = JsonConvert.DeserializeObject<List<IhaleBilgisiDTO>>(await responseMessage.Content.ReadAsStringAsync());
            }

            return listem;
        }

        public async Task<List<IhaleAraclariDTO>?> IhaledekiAraclariGetir(int id)
        {
            List<IhaleAraclariDTO>? listem = null;
            var responseMessage = await _httpClient.GetAsync($"Ihale/IhaleAraclar/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                listem = JsonConvert.DeserializeObject<List<IhaleAraclariDTO>>(await responseMessage.Content.ReadAsStringAsync());
            }

            return listem;
        }

        public async Task<IhaleBilgisiDTO?> IdyeGoreIhaleGetir(int id)
        {
	        ProviderBase<IhaleBilgisiDTO> ihale = new ProviderBase<IhaleBilgisiDTO>(_httpClient);

	       return await ihale.ProviderBaseGetAsync($"Ihale/{id}");

        }

        public async Task<IhaledekiAracFiyatBilgisiDTO?> AracIdyeGoreIhaleFiyatlariniGetir(int aracId)
        {
            ProviderBase<IhaledekiAracFiyatBilgisiDTO> ihale = new ProviderBase<IhaledekiAracFiyatBilgisiDTO>(_httpClient);

            return await ihale.ProviderBaseGetAsync($"Ihale/AracIhaleFiyat/{aracId}");

        }
	}
}
