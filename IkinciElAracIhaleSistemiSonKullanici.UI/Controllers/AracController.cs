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
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> AracDetay(int id)
		{
			var ihaledekiAraclar = await _provider.IhaledekiAracOzellikleriniGetir(id);
			var aracinFiyatBilgisi = await _provider.AracIdyeGoreAracIhaleFiyatiniGetir(id);
			var aracinTeklifleri = await _provider.IhaledekiAracTeklifleriniGetir(id);

			#region TempData

			string baslangicString = null;
			string bitisString = null;
			if (TempData.ContainsKey("ihaleBaslangic") && TempData.ContainsKey("ihaleBitis"))
			{
				string ihaleBaslangic = TempData["ihaleBaslangic"] as string;
				string ihaleBitis = TempData["ihaleBitis"] as string;

				baslangicString = ihaleBaslangic;
				bitisString = ihaleBitis;
			}
			TempData["AracId"] = aracinFiyatBilgisi.AracId.ToString();
			#endregion

			var model = new AracDetayViewModel
			{
				IhaledekiAraclar = ihaledekiAraclar,
				AracinFiyatBilgisi = aracinFiyatBilgisi,
				AracId = aracinFiyatBilgisi.AracId,
				AracTeklifleri = aracinTeklifleri,
				BaslangicString = baslangicString,
				BitisString = bitisString
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
				ViewBag.HataMesaji = "Teklifiniz kaydedilemedi. Lütfen doğru giriş yaptığınızdan emin olun!";
				return RedirectToAction("AracDetay", "Arac", new { id = aracId });
			}
			ViewBag.HataMesaji = "Teklifiniz kaydedilemedi. Lütfen doğru giriş yaptığınızdan emin olun!";
			return RedirectToAction("AracDetay", "Arac", new { id = aracId });


		}

	}
}
