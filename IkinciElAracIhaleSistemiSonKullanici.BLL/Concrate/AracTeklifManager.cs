using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.DAL.UnitOfWork;

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
		public async Task<IhaleTeklifVermeDTO> IhaledekiAracaYeniTeklifVerme(IhaleTeklifVermeDTO teklifDto)
		{
			DataManager data = new DataManager();
			await data.GetAracTeklifRepository().IhaledekiAracaTeklifVerme(teklifDto);
			return _mapper.Map<IhaleTeklifVermeDTO>(teklifDto);
		}
	}
}
