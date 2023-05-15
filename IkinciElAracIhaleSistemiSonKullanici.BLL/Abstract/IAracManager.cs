using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface IAracManager
	{
		public Task<List<IhaledekiAracFiyatBilgisiDTO>> IhaledekiAraclariGetir(int id);
	}
}
