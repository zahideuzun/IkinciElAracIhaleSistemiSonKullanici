using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.Data;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface ISayfaRepository : ISelectableRepo<Sayfa>, ISelectableRepoAsync<Sayfa>
	{
		public Task<List<Sayfa>> RoleGoreSayfaYetkileriniGetir(int uyeRol);
	}
}
