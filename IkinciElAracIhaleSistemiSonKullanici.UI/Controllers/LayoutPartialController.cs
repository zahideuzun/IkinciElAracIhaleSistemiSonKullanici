using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.UI.Models.Extension;
using Microsoft.AspNetCore.Mvc;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Controllers
{
    public class LayoutPartialController : Controller
    {
        private readonly IUyeManager _uyeManager;
        public LayoutPartialController(IUyeManager uyeManager)
        {
            _uyeManager = uyeManager; 
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public  PartialViewResult _FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult _HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult _NavbarPartial()
        {
	        return PartialView();
        }
        public PartialViewResult _ScriptsPartial()
        {
            return PartialView();
        }
    }
}
