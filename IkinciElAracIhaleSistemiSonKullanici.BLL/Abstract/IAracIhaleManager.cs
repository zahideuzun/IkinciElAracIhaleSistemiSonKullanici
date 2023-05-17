using IkinciElAracIhaleSistemi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface IAracIhaleManager
	{
		public Task<List<AracIhaleDTO>> IhaleIdyeGoreIhaledekiAracFiyatBilgileriniGetir(int ihaleId);
		public Task<AracIhaleDTO> AracIdyeGoreIhaledekiAracFiyatBilgisiniGetir(int aracId);
	}
}
