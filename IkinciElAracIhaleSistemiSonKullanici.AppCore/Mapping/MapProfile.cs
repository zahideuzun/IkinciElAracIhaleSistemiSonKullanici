using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.Mapping
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<AracTeklif, IhaleTeklifVermeDTO>();
			CreateMap<IhaleTeklifVermeDTO, AracTeklif>();

			CreateMap<IhaleBilgisiDTO, Ihale>()
				.ForMember(a => a.Id, opt => opt.MapFrom(x => x.IhaleId));
			CreateMap<Ihale, IhaleBilgisiDTO>()
				.ForMember(a => a.IhaleId, opt => opt.MapFrom(x => x.Id));

			CreateMap<AracIhale, IhaledekiAracFiyatBilgisiDTO>();
			CreateMap<IhaledekiAracFiyatBilgisiDTO, AracIhale>();

			CreateMap<AracBilgiDTO, Arac>();
			CreateMap<Arac, AracBilgiDTO>();

			CreateMap<IhaleTeklifVermeDTO, AracTeklif>();
			CreateMap<AracTeklif, IhaleTeklifVermeDTO>();

			CreateMap<UyeGirisDTO, Uye>();
			CreateMap<Uye, UyeGirisDTO>();

			CreateMap<Sayfa, UyeYetkiSayfaDTO>();
			CreateMap<UyeYetkiSayfaDTO, Sayfa>();


		}
	}
}
