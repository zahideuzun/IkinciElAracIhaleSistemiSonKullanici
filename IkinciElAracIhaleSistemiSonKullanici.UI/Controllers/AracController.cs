using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Controllers
{
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
			return View(ihaledekiAraclar);
			
		}
	}
}
