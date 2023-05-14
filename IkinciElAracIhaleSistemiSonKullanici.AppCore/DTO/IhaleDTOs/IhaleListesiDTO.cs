﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs
{
    public class IhaleListesiDTO
    {
        public int IhaleId { get; set; }
        public string IhaleAdi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
        public string Statu { get; set; }
        public string IhaleTuru { get; set; }
        public int OlusturanKullaniciId { get; set; }
        public string OlusturanKullanici { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int IhaleTuruId { get; set; }
    }
}
