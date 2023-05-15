using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
	public class AracTeklifManager : IAracManager
	{
		public Task<List<IhaledekiAracFiyatBilgisiDTO>> IhaledekiAraclariGetir(int id)
		{
			throw new NotImplementedException();
		}
	}
}
