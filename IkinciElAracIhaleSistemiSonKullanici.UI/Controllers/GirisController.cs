using IkinciElAracIhaleSistemiSonKullanici.AppCore.CacheHelper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using IkinciElAracIhaleSistemiSonKullanici.UI.Models.Extension;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Controllers
{
	[AllowAnonymous]
	public class GirisController : Controller
    {
        private readonly GirisProvider _provider;
        private readonly CacheHelper _cacheHelper;

        public GirisController(GirisProvider provider, CacheHelper cacheHelper)
        {
            _provider = provider;
            _cacheHelper = cacheHelper;
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

            //uye bilgisini sessionda tutuyoruz.
            var girisYapanUye = await _provider.KullaniciGirisKontrolTask(uye);

            if (girisYapanUye.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.HataMesaji = "Kullanıcı adı veya şifre hatalı";
                return View("Index");
			}
            HttpContext.Session.MySessionSet("girisYapanUye", girisYapanUye.Data);

            //todo daha efektif nasil yazilir? giris yapan uyenin rol bilgisi uye turune gore farkli tablodan geldigi icin rol bilgisini uye giris yaptiktan sonra kontrol etmek durumunda kaldim. ortak bir dto yapilip kontrol edilebilir mi?

            //burada cachede tutmak istedigimiz tipi vererek veriyi cache atiyoruz.
            var sayfalar = await _cacheHelper.CreateAndCacheList("RolSayfaCacheKey", async () =>
            {
                return await _provider.RoleGoreSayfalariDuzenle(girisYapanUye.Data.RolId);
            }, TimeSpan.FromMinutes(30));
            
            //uye authenticationi yapildi
            await AuthenticationAsync(uye);
            return RedirectToAction("Index", "Default");

		}

        [HttpGet]
        public async Task<IActionResult> Cikis()
        {
	        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
	        HttpContext.Session.Clear();
	        return RedirectToAction("Index","Giris");
        }

        [NonAction]
        public async Task AuthenticationAsync(UyeGirisDTO uye)
        {
	        var claims = new[] { new Claim(ClaimTypes.Name, uye.Email) };

	        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

	        await HttpContext.SignInAsync(
		        CookieAuthenticationDefaults.AuthenticationScheme,
		        new ClaimsPrincipal(identity));
        }

		[NonAction]
        public async Task<List<UyeYetkiSayfaDTO>> CacheAt(int rolId)
        {
            var sayfalar = await _cacheHelper.CreateAndCacheList("RolSayfaCacheKey", async () =>
            {
                return await _provider.RoleGoreSayfalariDuzenle(rolId);
            }, TimeSpan.FromMinutes(30));

            return sayfalar;
        }

    }
}
