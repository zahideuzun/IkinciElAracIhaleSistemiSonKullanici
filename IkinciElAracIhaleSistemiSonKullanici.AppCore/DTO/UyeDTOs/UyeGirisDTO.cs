using System.ComponentModel.DataAnnotations;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO
{
	public class UyeGirisDTO
    {
	    public string Isim { get; set; }
	    public string Soyisim { get; set; }
	    public int UyeTuruId { get; set; }

		[Required(ErrorMessage = "Lütfen mail adresinizi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Sifre { get; set; }


    }
}
