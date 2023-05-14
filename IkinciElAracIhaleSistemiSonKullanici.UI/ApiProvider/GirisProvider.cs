using IkinciElAracIhaleSistemiSonKullanici.AppCore.Bases;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;

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
            var result = await _httpClient.PostAsync($"Giris/Index/", new StringContent(JsonConvert.SerializeObject(uye), Encoding.UTF8, "application/json"));

            var data = JsonConvert.DeserializeObject<UyeSessionDTO>(await result.Content.ReadAsStringAsync());

            return new GeneralDataType<UyeSessionDTO>(result.RequestMessage?.ToString(), result.StatusCode, data);
        }

    }
}
