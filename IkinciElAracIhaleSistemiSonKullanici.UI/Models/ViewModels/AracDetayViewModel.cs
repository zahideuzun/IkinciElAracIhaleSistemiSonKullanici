using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.AracOzellikDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Models
{
	public class AracDetayViewModel
	{
		public IEnumerable<OzellikDetayDTO> IhaledekiAraclar { get; set; }
		public AracIhaleDTO AracinFiyatBilgisi { get; set; }
		public int AracId { get; set; }
		public List<AracTeklifDTO>? AracTeklifleri { get; internal set; }
		public string BaslangicString { get; set; }
		public string? BitisString { get; internal set; }
	}
}
