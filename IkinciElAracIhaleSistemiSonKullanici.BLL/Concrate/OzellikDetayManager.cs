using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.AracOzellikDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
	public class OzellikDetayManager : IOzellikDetayManager
	{
		private readonly IOzellikDetayRepository _repository;
		private readonly IMapper _mapper;
		public OzellikDetayManager(IOzellikDetayRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<List<OzellikDetayDTO>> AracOzellikleriniGetir(int id)
		{
			var idyeGoreAracIhale = await _repository.AracOzellikleriniGetir(id);
			return _mapper.Map<List<OzellikDetayDTO>>(idyeGoreAracIhale);
		}
	}
}
