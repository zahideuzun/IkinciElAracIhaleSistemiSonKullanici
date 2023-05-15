using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.Data;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IAracIhaleRepository : ISelectableRepo<AracIhale>, ISelectableRepoAsync<AracIhale>
	{
		public Task<AracIhale?> IhaledekiAracFiyatBilgisiniGetir(int aracId);
	}
}
