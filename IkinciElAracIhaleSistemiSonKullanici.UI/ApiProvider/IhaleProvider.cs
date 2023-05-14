using IkinciElAracIhaleSistemiSonKullanici.AppCore.Bases;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using Newtonsoft.Json;
using System.Text;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider
{
    public class IhaleProvider
    {
        HttpClient _httpClient;

        public IhaleProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<IhaleListesiDTO>?> IhaleListesiniGetir()
        {
            List<IhaleListesiDTO>? listem = null;
            var responseMessage = await _httpClient.GetAsync("Ihale/Index");
            if (responseMessage.IsSuccessStatusCode)
            {
                listem = JsonConvert.DeserializeObject<List<IhaleListesiDTO>>(await responseMessage.Content.ReadAsStringAsync());
            }

            return listem;
        }
    }
}
