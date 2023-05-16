using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
	public class SayfaManager : ISayfaManager
	{
		private readonly ISayfaRepository _repository;
		private readonly IMapper _mapper;

		public SayfaManager(ISayfaRepository repository, IMapper mapper)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<List<UyeYetkiSayfaDTO>> RoleGoreSayfaYetkileriniGetir(int uyeRol)
		{
			var sayfaListesi = await _repository.RoleGoreSayfaYetkileriniGetir(uyeRol);
			return _mapper.Map<List<UyeYetkiSayfaDTO>>(sayfaListesi);
		}
	}
}
