using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
	public class AracManager : IAracManager
	{
		private readonly IAracRepository _repository;
		private readonly IMapper _mapper;

		public AracManager(IAracRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<List<AracBilgiDTO>> IhaledekiAraclariGetir(int id)
		{
			var ihaledekiAraclar = await _repository.IhaledekiAraclariGetir(id);
			return _mapper.Map<List<AracBilgiDTO>>(ihaledekiAraclar);
		}
	}
}
