using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider.Bases;
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
		public async Task<IhaleBilgisiDTO[][]?> IhaleListesiniGetir()
		{
			ProviderBase<IhaleBilgisiDTO[]> ihale = new ProviderBase<IhaleBilgisiDTO[]>(_httpClient);

			return await ihale.ProviderBaseListGetAsync("Ihale/Index");

			//List<IhaleBilgisiDTO>? listem = null;
   //         var responseMessage = await _httpClient.GetAsync("Ihale/Index");
   //         if (responseMessage.IsSuccessStatusCode)
   //         {
   //             listem = JsonConvert.DeserializeObject<List<IhaleBilgisiDTO>>(await responseMessage.Content.ReadAsStringAsync());
   //         }

   //         return null;
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

	        ////IhaleBilgisiDTO? ihale = null;
	        ////         var responseMessage = await _httpClient.GetAsync($"Ihale/{id}");
	        ////         if (responseMessage.IsSuccessStatusCode)
	        ////         {
	        ////             ihale = JsonConvert.DeserializeObject<IhaleBilgisiDTO>(await responseMessage.Content.ReadAsStringAsync());
	        ////         }
	        ////         return ihale;
        }
        public async Task<IhaledekiAracFiyatBilgisiDTO?> AracIdyeGoreIhaleFiyatlariniGetir(int aracId)
        {
	        IhaledekiAracFiyatBilgisiDTO? ihale = null;
	        var responseMessage = await _httpClient.GetAsync($"Ihale/AracIhaleFiyat/{aracId}");
	        if (responseMessage.IsSuccessStatusCode)
	        {
		        ihale = JsonConvert.DeserializeObject<IhaledekiAracFiyatBilgisiDTO>(await responseMessage.Content.ReadAsStringAsync());
	        }
	        return ihale;
        }
	}
}
