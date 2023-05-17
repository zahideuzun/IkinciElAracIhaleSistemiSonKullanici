using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Controllers
{
    public class IhaleController : Controller
    {
        private readonly IhaleProvider _ihaleProvider;
        private readonly AracProvider _aracProvider;
        public IhaleController(IhaleProvider ihaleProvider, AracProvider aracProvider)
        {
            _ihaleProvider = ihaleProvider;
            _aracProvider = aracProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ihaleListesi = await _ihaleProvider.IhaleListesiniGetir();

            return View(ihaleListesi);
        }
        [HttpGet]
        public async Task<IActionResult> KurumsalIhale()
        {
	        var ihaleListesi = await _ihaleProvider.KurumsalIhaleleriGetir();

	        return View(ihaleListesi);
        }

		[HttpGet]
        public async Task<IActionResult> IhaleDetay(int id)
        {
	        ViewBag.IhaleBilgisi = await _ihaleProvider.IdyeGoreIhaleGetir(id);
	        var ihaledekiAracFiyatBilgileri =  await _ihaleProvider.IhaleIdyeGoreAracFiyatlariniGetir(id);
			// todo tempdata bilgisi gelecek
			//TempData["araIhaleFiyat"] = JsonConvert.SerializeObject(ihaledekiAracFiyatBilgileri);
			var ihaledekiAraclar = await _ihaleProvider.IhaledekiAraclariGetir(id);
	        return View(Tuple.Create(ihaledekiAraclar, ihaledekiAracFiyatBilgileri));
        }

        
    }
}
