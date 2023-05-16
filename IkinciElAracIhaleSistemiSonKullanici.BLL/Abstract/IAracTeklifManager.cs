using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface IAracTeklifManager
	{
		public Task<IhaleTeklifVermeDTO> IhaledekiAracaYeniTeklifVerme(IhaleTeklifVermeDTO teklifDto);
	}
}
