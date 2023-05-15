using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs
{
	public class AracBilgiDTO
	{
		public string Plaka { get; set; }
		public int MarkaId { get; set; }
		public int ModelId { get; set; }
		public decimal Km { get; set; }
	}
}
