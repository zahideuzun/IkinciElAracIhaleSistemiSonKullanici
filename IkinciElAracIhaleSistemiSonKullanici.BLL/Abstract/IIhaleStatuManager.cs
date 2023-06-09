﻿using IkinciElAracIhaleSistemi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface IIhaleStatuManager
	{
		public Task<IhaleStatuDTO> IhaleIdyeGoreIhaleStatuGetir(int id);
		public Task<List<IhaleStatuDTO>> IhaleStatuGetir();
	}
}
