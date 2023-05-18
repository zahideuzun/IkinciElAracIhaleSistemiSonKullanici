using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs
{
	public class IhaleStatuDTO
	{
		public int IhaleStatuId { get; set; }
		public DateTime Tarih { get; set; }
		public int IhaleId { get; set; }
		public int StatuId { get; set; }
	}
}
