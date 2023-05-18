using IkinciElAracIhaleSistemiSonKullanici.AppCore.BaseType;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IkinciElAracIhaleSistemiSonKullanici.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AracController : ControllerBase
	{
		private readonly IAracIhaleManager _aracIhaleManager;
		private readonly IAracManager _aracManager;
		private readonly IAracTeklifManager _aracTeklifManager;
		private readonly IOzellikDetayManager _ozellikDetayManager;
		public AracController(IAracIhaleManager aracIhaleManager, IAracManager aracManager, IAracTeklifManager aracTeklifManager, IOzellikDetayManager ozellikDetayManager)
		{
			_aracIhaleManager = aracIhaleManager;
			_aracManager = aracManager;
			_aracTeklifManager = aracTeklifManager;
			_ozellikDetayManager = ozellikDetayManager;
		}

		[HttpGet("AracDetay/{Id}")]
		public async Task<IActionResult> IdyeGoreAracOzellikleri(int id)
		{
			var ihaledekiAracOzellikleri = await _ozellikDetayManager.AracOzellikleriniGetir(id);
			return BaseActionType.ReturnResponse(ihaledekiAracOzellikleri);
		}


		[HttpGet("IhaleAraclar/{ihaleId}")]
		public async Task<IActionResult> IhaledekiAraclar(int ihaleId)
		{
			var ihaledekiAracListesi = await _aracManager.IhaledekiAraclariGetir(ihaleId);
			return BaseActionType.ReturnResponse(ihaledekiAracListesi);
		}

		[HttpGet("AracIhaleFiyat/{aracId}")]
		public async Task<IActionResult> IhaledekiAracFiyatBilgileri(int aracId)
		{
			var ihale = await _aracIhaleManager.AracIdyeGoreIhaledekiAracFiyatBilgisiniGetir(aracId);
			return BaseActionType.ReturnResponse(ihale);
		}

		[HttpPost("AracIhaleTeklif")]
		public async Task<IActionResult> IhaledekiAracaTeklifVer([FromBody] AracTeklifDTO teklif)
		{
			var teklifResult = await _aracTeklifManager.IhaledekiAracaYeniTeklifVerme(teklif);

			return BaseActionType.ReturnResponse(teklifResult);
		}

		[HttpGet("AracIhaleTeklif/{aracId}")]
		public async Task<IActionResult> IhaledekiAracTeklifBilgileri(int aracId)
		{
			var ihale = await _aracTeklifManager.AracaVerilenTeklifleriGetir(aracId);
			return BaseActionType.ReturnResponse(ihale);
		}
	}
}
