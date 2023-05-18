using IkinciElAracIhaleSistemiSonKullanici.AppCore.BaseType;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using Newtonsoft.Json;
using System.Text;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider
{
	public class GirisProvider
    {
        HttpClient _httpClient;

        public GirisProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GeneralDataType<UyeSessionDTO>> KullaniciGirisKontrolTask(UyeGirisDTO uye)
        {
            var result = await _httpClient.PostAsync("Giris/Index", new StringContent(JsonConvert.SerializeObject(uye), Encoding.UTF8, "application/json"));

            var data = JsonConvert.DeserializeObject<UyeSessionDTO>(await result.Content.ReadAsStringAsync());

            return new GeneralDataType<UyeSessionDTO>(result.RequestMessage?.ToString(), result.StatusCode, data);
        }

        public async Task<List<UyeYetkiSayfaDTO>> RoleGoreSayfalariDuzenle(int rolId)
        {
            List<UyeYetkiSayfaDTO>? listem = null;
            var responseMessage = await _httpClient.GetAsync($"Giris/Sayfa/{rolId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                listem = JsonConvert.DeserializeObject<List<UyeYetkiSayfaDTO>>(await responseMessage.Content.ReadAsStringAsync());
            }

            return listem;
        }

    }
}
