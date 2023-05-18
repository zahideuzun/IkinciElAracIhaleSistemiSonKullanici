using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.AracOzellikDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.MarkaDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.ModelDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.StatuDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.Mapping
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<AracTeklif, AracTeklifDTO>();
			CreateMap<AracTeklifDTO, AracTeklif>();

			CreateMap<IhaleBilgisiDTO, Ihale>()
				.ForMember(a => a.Id, opt => opt.MapFrom(x => x.IhaleId));
			CreateMap<Ihale, IhaleBilgisiDTO>()
				.ForMember(a => a.IhaleId, opt => opt.MapFrom(x => x.Id));

			CreateMap<AracIhale, AracIhaleDTO>()
				.ForMember(a=>a.AracIhaleId, opt=>opt.MapFrom(x=>x.Id));
			CreateMap<AracIhaleDTO, AracIhale>()
				.ForMember(a=>a.Id, opt=>opt.MapFrom(x=>x.AracIhaleId));

			CreateMap<AracBilgiDTO, Arac>();
			CreateMap<Arac, AracBilgiDTO>();

			CreateMap<AracTeklifDTO, AracTeklif>();
			CreateMap<AracTeklif, AracTeklifDTO>();

			CreateMap<UyeGirisDTO, Uye>();
			CreateMap<Uye, UyeGirisDTO>();

			CreateMap<Sayfa, UyeYetkiSayfaDTO>();
			CreateMap<UyeYetkiSayfaDTO, Sayfa>();

			CreateMap<OzellikDetay, OzellikDetayDTO>();
			CreateMap<OzellikDetayDTO, OzellikDetay>();

			CreateMap<Marka, MarkaDTO>();
			CreateMap<MarkaDTO, Marka>();

			CreateMap<Model, ModelDTO>();
			CreateMap<ModelDTO, Model>();

			CreateMap<IhaleTuru, IhaleTuruDTO>();
			CreateMap<IhaleTuruDTO, IhaleTuru>();

			CreateMap<Statu, StatuDTO>();
			CreateMap<StatuDTO, Statu>();

			CreateMap<IhaleStatu, IhaleStatuDTO>();
			CreateMap<IhaleStatuDTO, IhaleStatu>();

		}
	}
}
