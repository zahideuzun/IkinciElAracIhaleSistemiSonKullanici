
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
        public IhaleController(IIhaleManager ihaleManager)
        {
            _ihaleManager = ihaleManager;
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

        
    }
}
