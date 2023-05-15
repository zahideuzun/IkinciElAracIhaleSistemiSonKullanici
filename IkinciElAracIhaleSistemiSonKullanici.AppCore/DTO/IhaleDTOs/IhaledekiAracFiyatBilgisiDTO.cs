using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs
{
	public class IhaledekiAracFiyatBilgisiDTO
	{
		public int AracId { get; set; }
		public int IhaleId { get; set; }
		public decimal IhaleBaslangicFiyati { get; set; }
		public decimal MinimumAlimFiyati { get; set; }
	}
}
