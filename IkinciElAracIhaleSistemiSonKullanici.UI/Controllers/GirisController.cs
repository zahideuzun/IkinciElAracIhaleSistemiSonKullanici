using IkinciElAracIhaleSistemiSonKullanici.AppCore.CacheHelper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.RolYetkiDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using IkinciElAracIhaleSistemiSonKullanici.UI.Models.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Controllers
{
    //todo authentication??
    public class GirisController : Controller
    {
        private readonly GirisProvider _provider;
        private readonly CacheHelper _cacheHelper;
        private readonly IUyeManager _uyeManager;

        public GirisController(GirisProvider provider, IUyeManager uyeManager, CacheHelper cacheHelper)
        {
            _provider = provider;
            _uyeManager = uyeManager;
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
            HttpContext.Session.MySessionSet("girisYapanUye", girisYapanUye.Data);

            //todo daha efektif nasil yazilir? giris yapan uyenin rol bilgisi uye turune gore farkli tablodan geldigi icin rol bilgisini uye giris yaptiktan sonra kontrol etmek durumunda kaldim. ortak bir dto yapilip kontrol edilebilir mi?

            //burada cachede tutmak istedigimiz tipi vererek veriyi cache atiyoruz.
            var sayfalar = await _cacheHelper.CreateAndCacheList("RolSayfaCacheKey", async () =>
            {
                return await _provider.RoleGoreSayfalariDuzenle(girisYapanUye.Data.RolId);
            }, TimeSpan.FromMinutes(30));


            var cachedekiVeri =  _cacheHelper.GetCachedList<UyeYetkiSayfaDTO>("RolSayfaCacheKey");


            return RedirectToAction("Index", "Default");

        }

    }
}
