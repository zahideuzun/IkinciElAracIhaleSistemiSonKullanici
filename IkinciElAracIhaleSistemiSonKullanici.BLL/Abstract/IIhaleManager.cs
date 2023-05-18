using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
    public interface IIhaleManager
    {
        public Task<List<IhaleBilgisiDTO>> TumIhaleleriGetir();
        public Task<IhaleBilgisiDTO?> IdyeGoreIhaleGetir(int id);

        public Task<List<IhaleBilgisiDTO>> TumKurumsalIhaleleriGetir();
        public Task<List<IhaleBilgisiDTO>> KurumsalFirmayaAitIhaleleriGetir(int id);
        public Task<List<IhaleBilgisiDTO>> BireyselIhaleleriGetir();
	}
}
