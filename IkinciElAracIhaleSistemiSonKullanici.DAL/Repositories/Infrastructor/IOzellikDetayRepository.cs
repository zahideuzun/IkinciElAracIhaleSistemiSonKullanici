using IkinciElAracIhaleSistemi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IOzellikDetayRepository
	{
		public Task<List<OzellikDetay>> AracOzellikleriniGetir(int id);
	}
}
