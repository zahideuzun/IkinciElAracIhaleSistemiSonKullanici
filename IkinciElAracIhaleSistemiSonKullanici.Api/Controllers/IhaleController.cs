using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate;
using Microsoft.AspNetCore.Http;
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
    }
}
