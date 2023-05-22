using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using IkinciElAracIhaleSistemiSonKullanici.UI.Models.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Controllers
{
	[Authorize]
	public class IhaleController : Controller
	{
		private readonly IhaleProvider _ihaleProvider;
		public IhaleController(IhaleProvider ihaleProvider)
		{
			_ihaleProvider = ihaleProvider;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var sessiondakiUyeBilgisi = HttpContext.Session.MySessionGet<UyeSessionDTO>("girisYapanUye");
			var ihaleler = await _ihaleProvider.IhaleListesiniGetir(sessiondakiUyeBilgisi.UyeTuruId);
			var ihaleStatuleri = await _ihaleProvider.IhaleStatuleriniGetir();

			return View(Tuple.Create(ihaleler, ihaleStatuleri));
		}
		[HttpGet]
		public async Task<IActionResult> KurumsalIhale()
		{
			var ihaleler = await _ihaleProvider.KurumsalIhaleleriGetir();
			return View(ihaleler);
		}

		[HttpGet]
		public async Task<IActionResult> IhaleDetay(int id)
		{
			var idIhale = await _ihaleProvider.IdyeGoreIhaleGetir(id);
			var ihaledekiAracFiyatBilgileri = await _ihaleProvider.IhaleIdyeGoreAracFiyatlariniGetir(id);
			var ihaledekiAraclar = await _ihaleProvider.IhaledekiAraclariGetir(id);
			var idIhaleStatu = await _ihaleProvider.IhaleStatuGetir(id);

			TempData["ihaleStatu"] = idIhaleStatu.Statu.StatuId.ToString();
			

			return View(Tuple.Create(ihaledekiAraclar, ihaledekiAracFiyatBilgileri, idIhale, idIhaleStatu));
		}


	}
}
