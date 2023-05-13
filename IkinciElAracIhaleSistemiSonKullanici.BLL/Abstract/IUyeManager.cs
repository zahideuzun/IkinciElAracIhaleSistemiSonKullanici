using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
    public interface IUyeManager
    {
        public Task<UyeSessionDTO> UyeKontrol(UyeGirisDTO uye);
    }
}
