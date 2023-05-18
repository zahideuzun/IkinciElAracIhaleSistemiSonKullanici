using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
	public class AracIhaleManager : IAracIhaleManager
	{
		private readonly IAracIhaleRepository _repository;
		private readonly IMapper _mapper;

		public AracIhaleManager(IAracIhaleRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<AracIhaleDTO> AracIdyeGoreIhaledekiAracFiyatBilgisiniGetir(int aracId)
		{
			var ihaledekiAracFiyatBilgisi = await _repository.AracIdyeGoreIhaledekiAracFiyatBilgisiniGetir(aracId);
			return _mapper.Map<AracIhaleDTO>(ihaledekiAracFiyatBilgisi);
		}

		public async Task<List<AracIhaleDTO>> IhaleIdyeGoreIhaledekiAracFiyatBilgileriniGetir(int ihaleId)
		{
			var ihaledekiAracFiyatBilgisi = await _repository.IhaleIdyeGoreIhaledekiAracFiyatBilgileriniGetir(ihaleId);
			return _mapper.Map<List<AracIhaleDTO>>(ihaledekiAracFiyatBilgisi);
		}
	}
}
