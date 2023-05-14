using AutoMapper;
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
        private readonly IMapper _mapper;
        public GirisController(IUyeManager uyeManager, IMapper mapper)
        {
            _uyeManager = uyeManager;
            _mapper = mapper;
        }
        [HttpPost("Index")]
        public async Task<IActionResult> UyeGiris([FromBody] UyeGirisDTO uye)
        {
            if (!ModelState.IsValid && uye ==null)
            {
                return BadRequest();
            }

            var girisYapanUye = await _uyeManager.UyeKontrol(uye);
            return Ok(girisYapanUye);

        }
    }
}
