using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IkinciElAracIhaleSistemiSonKullanici.Api.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class IhaleController : ControllerBase
    {
        private readonly IIhaleManager _ihaleManager;
        public IhaleController(IIhaleManager ihaleManager)
        {
            _ihaleManager = ihaleManager;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> IhaleGet()
        {
            var ihaleListesi = await _ihaleManager.TumIhaleleriGetir();
            if (ihaleListesi ==null)
            {
                return BadRequest();
            }
            return Ok(ihaleListesi);
        }

        [HttpGet("IhaleAraclar/{Id}")]
        public async Task<IActionResult> IhaledekiAraclar(int id)
        {
            //var ihaleListesi = await _ihaleManager.IhaledekiAraclariGetir(id);
            //if (ihaleListesi == null)
            //{
            //    return BadRequest();
            //}
            //return Ok(ihaleListesi);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> IdyeGoreGelenIhale(int id)
        {
            var ihale = await _ihaleManager.IdyeGoreIhaleGetir(id);
            if (ihale == null)
            {
                return BadRequest();
            }
            return Ok(ihale);
        }
        [HttpGet("AracIhaleFiyat/{aracId}")]
        public async Task<IActionResult> IhaledekiAracFiyatBilgileri(int aracId)
        {
            //var ihale = await _ihaleManager.IhaledekiAracBilgisiniGetir(aracId);
            //if (ihale == null)
            //{
            //    return BadRequest();
            //}
            //return Ok(ihale);
            return Ok();
        }
    }
}
