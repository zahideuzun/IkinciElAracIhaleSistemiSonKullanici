using IkinciElAracIhaleSistemi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.RolYetkiDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface ISayfaManager
	{
		public Task<List<UyeYetkiSayfaDTO>> RoleGoreSayfaYetkileriniGetir(int uyeRol);
	}
}
