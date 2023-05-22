using AutoMapper;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
	public class IhaleStatuManager : IIhaleStatuManager
	{
		private readonly IIhaleStatuRepository _repository;
		private readonly IMapper _mapper;

		public IhaleStatuManager(IIhaleStatuRepository repository, IMapper mapper)
		{
			_mapper = mapper;
			_repository = repository;
		}
		public async Task<IhaleStatuDTO> IhaleIdyeGoreIhaleStatuGetir(int id)
		{
			var ihaleStatu = await _repository.IhaleIdyeGoreIhaleStatuGetir(id);
			return _mapper.Map<IhaleStatuDTO>(ihaleStatu);
		}

		public async Task<List<IhaleStatuDTO>> IhaleStatuGetir()
		{
			var ihaleStatu = await _repository.IhaleStatuGetir();
			return _mapper.Map<List<IhaleStatuDTO>>(ihaleStatu);
		}
	}
}
