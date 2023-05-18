using IkinciElAracIhaleSistemiSonKullanici.Validation.ValidationBase;
using System.Configuration;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;


namespace IkinciElAracIhaleSistemiSonKullanici.UI.Validations
{
	public class AracTeklifValidator : ValidatorBase<IhaleTeklifVermeDTO>
	{
		public AracTeklifValidator(IhaleTeklifVermeDTO model) : base(model)
		{

		}

		public override void OnValidate()
		{
			if (string.IsNullOrEmpty(Model.TeklifEdilenFiyat.ToString()))
			{
				IsValid = false;
				ValidationMessages.Add("Lütfen bir teklif fiyatı giriniz!");
			}
			else if (!IsNumeric(Model.TeklifEdilenFiyat.ToString()))
			{
				IsValid = false;
				ValidationMessages.Add("Lütfen geçerli bir teklif fiyatı giriniz!");
			}

		}
		private bool IsNumeric(string value)
		{
			double number;
			return double.TryParse(value, out number);
		}
	}
}
