using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.MarkaDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.ModelDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs
{
	public class AracBilgiDTO
	{
		public int Id { get; set; }
		public string Plaka { get; set; }
		public int MarkaId { get; set; }
		public int ModelId { get; set; }
		public decimal Km { get; set; }
		public int Yil { get; set; }
		public MarkaDTO Marka { get; set; }
		public ModelDTO Model { get; set; }
	}
}
