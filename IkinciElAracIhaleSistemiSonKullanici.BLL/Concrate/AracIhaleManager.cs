using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs;
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
		public async Task<IhaledekiAracFiyatBilgisiDTO> IhaledekiAracFiyatBilgisiniGetir(int aracId)
		{
			var ihaledekiAracFiyatBilgisi = await _repository.IhaledekiAracFiyatBilgisiniGetir(aracId);
			return _mapper.Map<IhaledekiAracFiyatBilgisiDTO>(ihaledekiAracFiyatBilgisi);
		}
	}
}
