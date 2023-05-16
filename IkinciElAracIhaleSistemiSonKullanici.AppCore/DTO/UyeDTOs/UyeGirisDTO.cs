using System.ComponentModel.DataAnnotations;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO
{
	public class UyeGirisDTO
    {
        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Sifre { get; set; }

    }
}
