
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
        private readonly IAracManager _aracManager;
        private readonly IAracTeklifManager _aracTeklifManager;
        public IhaleController(IIhaleManager ihaleManager, IAracIhaleManager aracIhaleManager, IAracManager aracManager, IAracTeklifManager aracTeklifManager)
        {
            _ihaleManager = ihaleManager;
            _aracIhaleManager = aracIhaleManager;
            _aracManager = aracManager;
            _aracTeklifManager = aracTeklifManager;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> IhaleGet()
        {
            var ihaleListesi = await _ihaleManager.TumIhaleleriGetir();
			return BaseActionType.ReturnResponse(ihaleListesi);
		}

        [HttpGet("IhaleAraclar/{Id}")]
        public async Task<IActionResult> IhaledekiAraclar(int id)
        {
            var ihaledekiAracListesi = await _aracManager.IhaledekiAraclariGetir(id);
			return BaseActionType.ReturnResponse(ihaledekiAracListesi);
		}

        [HttpGet("{Id}")]
        public async Task<IActionResult> IdyeGoreGelenIhale(int id)
        {
            var ihale = await _ihaleManager.IdyeGoreIhaleGetir(id);
			return BaseActionType.ReturnResponse(ihale);
		}

        [HttpGet("AracIhaleFiyat/{aracId}")]
        public async Task<IActionResult> IhaledekiAracFiyatBilgileri(int aracId)
        {
            var ihale = await _aracIhaleManager.IhaledekiAracFiyatBilgisiniGetir(aracId);
			return BaseActionType.ReturnResponse(ihale);
		}
    }
}
