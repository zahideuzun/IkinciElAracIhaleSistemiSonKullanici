using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IAracRepository : ISelectableRepo<Arac>, ISelectableRepoAsync<Arac>
	{
		public Task<List<Arac>> IhaledekiAraclariGetir(int id);
	}
}
