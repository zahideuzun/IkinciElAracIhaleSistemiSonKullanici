using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
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

        [HttpPost]
        public async Task<IActionResult> Index(UyeGirisDTO uye)
        {
            if (!ModelState.IsValid && uye==null)
            {
                RedirectToAction("Index", "Giris");
            }
            else
            {
                var girisYapanUye = await _provider.KullaniciGirisKontrolTask(uye);
                RedirectToAction("Index", "Default");
            }
            return View();
            
        }
    }
}
