using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using IkinciElAracIhaleSistemiSonKullanici.UI.Models.Extension;
using Microsoft.AspNetCore.Mvc;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Controllers
{
    public class GirisController : Controller
    {
        private readonly GirisProvider _provider;

        public GirisController(GirisProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UyeGirisDTO uye)
        {
            if (!ModelState.IsValid && uye == null)
            {
                return RedirectToAction("Index", "Giris");
            }

            var girisYapanUye = await _provider.KullaniciGirisKontrolTask(uye);
            HttpContext.Session.MySessionSet("girisYapanUye", girisYapanUye.Data);
            
            //todo uye bilgilerini sessiondan alarak menuyu duzenle
            //var sessiondakiUyeBilgisi = HttpContext.Session.MySessionGet<UyeSessionDTO>("girisYapanUye");

            return RedirectToAction("Index", "Default");

        }
    }
}
