using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Bases;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace IkinciElAracIhaleSistemiSonKullanici.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GirisController : ControllerBase
    {
        private readonly IUyeManager _uyeManager;
        public GirisController(IUyeManager uyeManager)
        {
            _uyeManager = uyeManager;
           
        }
        [HttpPost("Index")]
        public async Task<IActionResult> UyeGiris([FromBody] UyeGirisDTO uye)
        {
	        var girisYapanUye = await _uyeManager.UyeKontrol(uye);
			return BaseActionType.ReturnResponse(girisYapanUye);
        }
    }
}
