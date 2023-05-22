using IkinciElAracIhaleSistemi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemiSonKullanici.Data;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IIhaleStatuRepository : ISelectableRepoAsync<IhaleStatu>, ISelectableRepo<IhaleStatu>
	{
		public Task<IhaleStatu> IhaleIdyeGoreIhaleStatuGetir(int id);
		public Task<List<IhaleStatu>> IhaleStatuGetir();
	}
}
