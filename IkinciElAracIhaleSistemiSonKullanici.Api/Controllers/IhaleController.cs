
using IkinciElAracIhaleSistemiSonKullanici.AppCore.BaseType;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IkinciElAracIhaleSistemiSonKullanici.Api.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class IhaleController : ControllerBase
    {
        private readonly IIhaleManager _ihaleManager;
        private readonly IAracIhaleManager _aracIhaleManager;
        private readonly IIhaleStatuManager _ihaleStatuManager;
		public IhaleController(IIhaleManager ihaleManager, IAracIhaleManager aracIhaleManager, IIhaleStatuManager ihaleStatuManager)
        {
            _ihaleManager = ihaleManager;
            _aracIhaleManager = aracIhaleManager;
			_ihaleStatuManager = ihaleStatuManager;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> IhaleGet()
        {
            var ihaleListesi = await _ihaleManager.TumIhaleleriGetir();
			return BaseActionType.ReturnResponse(ihaleListesi);
		}

        [HttpGet("{Id}")]
        public async Task<IActionResult> IdyeGoreGelenIhale(int id)
        {
            var ihale = await _ihaleManager.IdyeGoreIhaleGetir(id);
			return BaseActionType.ReturnResponse(ihale);
		}
        [HttpGet("Statu")]
        public async Task<IActionResult> IhaleStatu(int id)
        {
	        var ihale = await _ihaleStatuManager.IhaleIdyeGoreIhaleStatuGetir(id);
	        return BaseActionType.ReturnResponse(ihale);
        }
        [HttpGet("StatuIndex")]
        public async Task<IActionResult> IhaleStatuGet()
        {
	        var ihaleListesi = await _ihaleStatuManager.IhaleStatuGetir();
	        return BaseActionType.ReturnResponse(ihaleListesi);
        }


		[HttpGet("AracIhaleFiyat/{ihaleId}")]
		public async Task<IActionResult> IhaledekiAracFiyatBilgileri(int ihaleId)
		{
			var ihale = await _aracIhaleManager.IhaleIdyeGoreIhaledekiAracFiyatBilgileriniGetir(ihaleId);
			return BaseActionType.ReturnResponse(ihale);
		}

		[HttpGet("KurumsalIhale")]
		public async Task<IActionResult> KurumsalIhaleGetir()
		{
			var ihaleListesi = await _ihaleManager.TumKurumsalIhaleleriGetir();
			return BaseActionType.ReturnResponse(ihaleListesi);
		}

		[HttpGet("BireyselIhale")]
		public async Task<IActionResult> BireyselIhaleGetir()
		{
			var ihaleListesi = await _ihaleManager.BireyselIhaleleriGetir();
			return BaseActionType.ReturnResponse(ihaleListesi);
		}

		[HttpGet("KurumsalIhale/{firmaId}")]
		public async Task<IActionResult> IdyeGoreKurumsalIhaleGetir(int firmaId)
		{
			var ihaleListesi = await _ihaleManager.KurumsalFirmayaAitIhaleleriGetir(firmaId);
			return BaseActionType.ReturnResponse(ihaleListesi);
		}
	}
}
