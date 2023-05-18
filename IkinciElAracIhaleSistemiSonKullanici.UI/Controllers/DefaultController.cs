using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Controllers
{
	[Authorize]
    public class DefaultController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
