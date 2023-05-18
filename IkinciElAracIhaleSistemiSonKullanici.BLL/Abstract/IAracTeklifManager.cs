using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results.Bases;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface IAracTeklifManager
	{
		public Result IhaledekiAracaYeniTeklifVerme(IhaleTeklifVermeDTO teklifDto);
	}
}
