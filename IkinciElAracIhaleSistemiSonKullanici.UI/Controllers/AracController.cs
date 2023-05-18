using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results;
using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using IkinciElAracIhaleSistemiSonKullanici.UI.Models;
using IkinciElAracIhaleSistemiSonKullanici.UI.Models.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Controllers
{
	[Authorize]
	public class AracController : Controller
	{
		private readonly AracProvider _provider;
		

		public AracController(AracProvider provider)
		{
			_provider = provider;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> AracDetay(int id)
		{
			var ihaledekiAraclar = await _provider.IhaledekiAracOzellikleriniGetir(id);
			var aracinFiyatBilgisi = await _provider.AracIdyeGoreAracIhaleFiyatiniGetir(id);

			var model = new AracDetayViewModel
			{
				IhaledekiAraclar = ihaledekiAraclar,
				AracinFiyatBilgisi = aracinFiyatBilgisi,
				AracId = aracinFiyatBilgisi.AracId
			};

			TempData["AracId"] = aracinFiyatBilgisi.AracId.ToString();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> TeklifVer(IhaleTeklifVermeDTO teklif)
		{
			int aracId = 0;
			if (TempData.ContainsKey("AracId"))
			{
				string aracIdString = TempData["AracId"] as string;
				int.TryParse(aracIdString, out aracId);
			}
			var sessiondakiUyeBilgisi = HttpContext.Session.MySessionGet<UyeSessionDTO>("girisYapanUye");
            teklif.UyeId = sessiondakiUyeBilgisi.UyeId;
			teklif.TeklifTarihi = DateTime.Now;
            teklif.OnaylandiMi = false;

			var sonuc = await _provider.IhaledekiAracaTeklifVerme(teklif);

			if (sonuc.IsSuccessful)
			{
				return RedirectToAction("AracDetay", "Arac", new { id = aracId });
			}

			return BadRequest();

		}
	}
}
