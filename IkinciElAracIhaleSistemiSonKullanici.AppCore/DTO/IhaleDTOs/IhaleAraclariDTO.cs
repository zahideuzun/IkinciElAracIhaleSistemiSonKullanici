using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs
{
	public class IhaleAraclariDTO
	{
		public int AracId { get; set; }
		public string Plaka { get; set; }
		public string Marka { get; set; }
		public string Model { get; set; }
		public decimal Km { get; set; }

	}
}
