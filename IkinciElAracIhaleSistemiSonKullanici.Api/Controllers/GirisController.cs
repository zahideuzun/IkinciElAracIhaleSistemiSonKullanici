using IkinciElAracIhaleSistemiSonKullanici.AppCore.BaseType;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IkinciElAracIhaleSistemiSonKullanici.Api.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class GirisController : ControllerBase
    {
        private readonly IUyeManager _uyeManager;
        private readonly ISayfaManager _sayfaManager;
        public GirisController(IUyeManager uyeManager, ISayfaManager sayfaManager)
        {
            _uyeManager = uyeManager;
            _sayfaManager = sayfaManager;
        }
        [HttpPost("Index")]
        public async Task<IActionResult> UyeGiris([FromBody] UyeGirisDTO uye)
        {
	        var girisYapanUye = await _uyeManager.UyeKontrol(uye);
			return BaseActionType.ReturnResponse(girisYapanUye);
        }
        [HttpGet("Sayfa/{Id}")]
        public async Task<IActionResult> RoleGoreSayfalariGetir(int Id)
        {
            var girisYapanUye = await _sayfaManager.RoleGoreSayfaYetkileriniGetir(Id);
            return BaseActionType.ReturnResponse(girisYapanUye);
        }
    }
}
