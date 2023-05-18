using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;

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

		public async Task<UyeSessionDTO> UyeKontrol(UyeGirisDTO uye)
		{
			return await _repository.UyeKontrol(uye);
        }

		public int UyeRolunuGetir(int uyeRol)
		{
            var rolId =  _repository.UyeRolunuGetir(uyeRol);
			return rolId;
        }
	}
}
