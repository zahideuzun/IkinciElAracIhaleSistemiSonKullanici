using IkinciElAracIhaleSistemi.Entities.Entities.Bases;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs
{
	public class AracTeklifDTO : IModel
	{
		public int AracIhaleId { get; set; }
		public int UyeId { get; set; }
		public decimal TeklifEdilenFiyat { get; set; }
		public DateTime TeklifTarihi { get; set; }
		public bool OnaylandiMi { get; set; }
		public AracIhaleDTO AracIhale { get; set; }
	}
}
