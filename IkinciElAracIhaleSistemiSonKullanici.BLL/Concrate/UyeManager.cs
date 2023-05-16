using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Enums;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.DAL.UnitOfWork;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
    public class UyeManager : IUyeManager
    {
		private readonly IUyeRepository _repository;
		private readonly IMapper _mapper;

		public UyeManager(IUyeRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<UyeGirisDTO> UyeKontrol(UyeGirisDTO uye)
		{
			var girisYapanUye = await _repository.UyeKontrol(uye);
			return _mapper.Map<UyeGirisDTO>(girisYapanUye);
		}

		public async Task<int> UyeRolunuGetir(int uyeTuruId)
		{
			var rolId = await _repository.UyeRolunuGetir(uyeTuruId);
			return rolId;
		}
	}
}
