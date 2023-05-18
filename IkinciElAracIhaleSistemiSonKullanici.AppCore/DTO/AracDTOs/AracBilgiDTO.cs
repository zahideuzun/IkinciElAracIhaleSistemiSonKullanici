using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.MarkaDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.ModelDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs
{
	public class AracBilgiDTO
	{
		public int Id { get; set; }
		public string Plaka { get; set; }
		public decimal Km { get; set; }
		public MarkaDTO Marka { get; set; }
		public ModelDTO Model { get; set; }
	}
}
