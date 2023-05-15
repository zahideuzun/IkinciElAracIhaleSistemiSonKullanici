﻿using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Controllers
{
    public class IhaleController : Controller
    {
        private readonly IhaleProvider _ihaleProvider;
        public IhaleController(IhaleProvider ihaleProvider)
        {
            _ihaleProvider = ihaleProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ihaleListesi = await _ihaleProvider.IhaleListesiniGetir();
            return View(ihaleListesi);
        }

        [HttpGet]
        public async Task<IActionResult> IhaleDetay(int id)
        {
            var idyeGoreGelenIhale = await _ihaleProvider.IdyeGoreIhaleGetir(id);
            ViewBag.IhaleBilgisi = idyeGoreGelenIhale;
            var ihaledekiAraclar = await _ihaleProvider.IhaledekiAraclariGetir(id);
	        return View(ihaledekiAraclar);
        }
    }
}
