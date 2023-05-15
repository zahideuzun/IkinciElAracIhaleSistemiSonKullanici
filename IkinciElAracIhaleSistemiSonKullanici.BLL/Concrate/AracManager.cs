using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
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
		public async Task<List<IhaledekiAracFiyatBilgisiDTO>> IhaledekiAraclariGetir(int id)
		{
			var ihaledekiAraclar = await _repository.IhaledekiAraclariGetir(id);
			return _mapper.Map<List<IhaledekiAracFiyatBilgisiDTO>>(ihaledekiAraclar);
		}
	}
}
