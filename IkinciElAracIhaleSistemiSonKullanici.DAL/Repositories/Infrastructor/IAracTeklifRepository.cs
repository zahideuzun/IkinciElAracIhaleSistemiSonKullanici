using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.Data;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IAracTeklifRepository : IInsertableRepo<AracTeklif>, IInsertableRepoAsync<AracTeklif>
	{
		public Task<AracTeklif> IhaledekiAracaTeklifVerme(IhaleTeklifBilgileriDTO teklifDto);
	}
}
