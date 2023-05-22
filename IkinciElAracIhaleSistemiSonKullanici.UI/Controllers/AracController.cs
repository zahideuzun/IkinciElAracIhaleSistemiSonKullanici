using IkinciElAracIhaleSistemiSonKullanici.AppCore.BaseType;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using IkinciElAracIhaleSistemiSonKullanici.UI.Models;
using IkinciElAracIhaleSistemiSonKullanici.UI.Models.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
		
		[HttpGet]
		public async Task<IActionResult> AracDetay(int id)
		{
			var ihaledekiAraclar = await _provider.IhaledekiAracOzellikleriniGetir(id);
			var aracinFiyatBilgisi = await _provider.AracIdyeGoreAracIhaleFiyatiniGetir(id);
			var aracinTeklifleri = await _provider.IhaledekiAracTeklifleriniGetir(id);

			#region TempData

			TempData.Put("aracId", aracinFiyatBilgisi);

			TempData.Get<IhaleStatuDTO>("ihaleStatu");
			#endregion

			var model = new AracDetayViewModel
			{
				IhaledekiAraclar = ihaledekiAraclar,
				AracinFiyatBilgisi = aracinFiyatBilgisi,
				AracId = aracinFiyatBilgisi.AracId,
				AracTeklifleri = aracinTeklifleri,
			};
			

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> TeklifVer(AracTeklifDTO teklif)
		{
			#region TempData

			int aracId = 0;
			if (TempData.ContainsKey("AracId"))
			{
				string aracIdString = TempData["AracId"] as string;
				int.TryParse(aracIdString, out aracId);
			}

			#endregion

			var sessiondakiUyeBilgisi = HttpContext.Session.MySessionGet<UyeSessionDTO>("girisYapanUye");
            teklif.UyeId = sessiondakiUyeBilgisi.UyeId;
			teklif.TeklifTarihi = DateTime.Now;
            teklif.OnaylandiMi = false;

			var sonuc = await _provider.IhaledekiAracaTeklifVerme(teklif);
			if (sonuc.IsSuccessful)
			{
				return RedirectToAction("Index", "Ihale" /*new { id = aracId }*/);
			}
			ViewBag.HataMesaji = "Teklifiniz kaydedilemedi. Lütfen doğru giriş yaptığınızdan emin olun!";
			return RedirectToAction("AracDetay", "Arac", new { id = aracId });


		}

	}
}
