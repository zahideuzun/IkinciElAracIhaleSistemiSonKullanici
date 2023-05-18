using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results.Bases;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;

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
			var deneme = _repository.IhaledekiAracaTeklifVerme(teklifDto);
			return deneme;


			//var deneme = _mapper.Map<AracTeklif>(teklifDto);
			//DataManager data = new DataManager();
			//var test = data.GetAracTeklifRepository().Add(deneme);
			//data.MySaveChanges();
			//retu test != null
			//	? new SuccessResult("Teklifiniz kaydedildi!")
			//	: new ErrorResult("Teklif kaydedilemedi!");
		}

	}
}
