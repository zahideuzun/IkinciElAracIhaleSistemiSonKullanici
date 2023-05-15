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
        public Task<List<IhaleListesiDTO>> TumIhaleleriGetir();

        public Task<List<IhaleAraclariDTO>> IhaledekiAraclariGetir(int id);

        public Task<IhaleListesiDTO?> IdyeGoreIhaleGetir(int id);

        public Task<IhaledekiAracBilgisiDTO?> IhaledekiAracBilgisiniGetir(int id);

    }
}
