using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using IkinciElAracIhaleSistemiSonKullanici.UI.Models;
using IkinciElAracIhaleSistemiSonKullanici.UI.Models.Extension;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Controllers
{
	public class AracController : Controller
	{
		private readonly AracProvider _provider;
		private readonly IhaleProvider _ihaleProvider;

		public AracController(AracProvider provider, IhaleProvider ihaleProvider)
		{
			_provider = provider;
			_ihaleProvider = ihaleProvider;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> AracDetay(int id)
		{
			//var ihaledekiAraclar = await _provider.IhaledekiAracOzellikleriniGetir(id);
			//var aracinFiyatBilgisi = await _ihaleProvider.AracIdyeGoreIhaleFiyatlariniGetir(id);
			////todo tempdata kontrol et??
			//TempData["aracId"] = id.ToString();
			//string araIhaleJson = TempData["araIhaleFiyat"] as string;
			//var araIhaleFiyat = JsonConvert.DeserializeObject<AracIhaleDTO>(araIhaleJson);
			//ViewBag.AracId = aracinFiyatBilgisi.AracId;

			var ihaledekiAraclar = await _provider.IhaledekiAracOzellikleriniGetir(id);
			var aracinFiyatBilgisi = await _provider.AracIdyeGoreAracIhaleFiyatiniGetir(id);

			var model = new AracDetayViewModel
			{
				IhaledekiAraclar = ihaledekiAraclar,
				AracinFiyatBilgisi = aracinFiyatBilgisi,
				AracId = aracinFiyatBilgisi.AracId
			};

			TempData["AracId"] = aracinFiyatBilgisi.AracId.ToString();

			//return View(Tuple.Create(ihaledekiAraclar, aracinFiyatBilgisi));
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
           return RedirectToAction("Index", "Arac", new { id= aracId});
		}
	}
}
