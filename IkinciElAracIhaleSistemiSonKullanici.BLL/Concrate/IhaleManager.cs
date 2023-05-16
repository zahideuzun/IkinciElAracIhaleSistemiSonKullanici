using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
	public class IhaleManager : IIhaleManager
    {
	    private readonly IIhaleRepository _repository;
        private readonly IMapper _mapper;
        public IhaleManager(IIhaleRepository repository, IMapper mapper)
        {
	        _repository = repository;
            _mapper = mapper;
        }

        //todo ihale statu durumunu tarihe göre otomatik degistir

        public async Task<IhaleBilgisiDTO?> IdyeGoreIhaleGetir(int id)
        {
	        var idyeGoreIhale = await _repository.IdyeGoreIhaleGetir(id);
	        return _mapper.Map<IhaleBilgisiDTO>(idyeGoreIhale);
        }


        public async Task<List<IhaleBilgisiDTO>> TumIhaleleriGetir()
        {
	        var ihaleler = await _repository.TumIhaleleriGetir();
	        return _mapper.Map<List<IhaleBilgisiDTO>>(ihaleler);
        }

    }
}
