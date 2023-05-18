using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.DAL.UnitOfWork;
using System.Transactions;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results.Bases;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
	public class AracTeklifManager : IAracTeklifManager
	{
		private readonly IAracTeklifRepository _repository;
		private readonly IMapper _mapper;

		public AracTeklifManager(IAracTeklifRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public Result IhaledekiAracaYeniTeklifVerme(IhaleTeklifVermeDTO teklifDto)
		{
			//var deneme = _mapper.Map<AracTeklif>(teklifDto);
			//DataManager data = new DataManager();
			//var test = data.GetAracTeklifRepository().Add(deneme);
			
			var deneme = _repository.IhaledekiAracaTeklifVerme(teklifDto);
			return deneme;

			//data.MySaveChanges();
			//return test != null
			//	? new SuccessResult("Teklifiniz kaydedildi!")
			//	: new ErrorResult("Teklif kaydedilemedi!");
		}

	}
}
