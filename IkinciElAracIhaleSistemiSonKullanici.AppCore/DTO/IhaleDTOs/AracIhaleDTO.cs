namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs
{
	public class AracIhaleDTO
	{
		//todo teklif ekraninda yazdirilacak
		public int AracIhaleId { get; set; }
		public int AracId { get; set; }
		public int IhaleId { get; set; }
		public decimal IhaleBaslangicFiyati { get; set; }
		public decimal MinimumAlimFiyati { get; set; }
	}
}
