﻿using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs
{
	public class IhaleBilgisiDTO
    {
        //todo ihaleleri listeledigin yerde bilgileri ver
        public int IhaleId { get; set; }
        public string IhaleAdi { get; set; }
        public DateTime IhaleBaslangicTarihi { get; set; }
        public DateTime IhaleBitisTarihi { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
		public ICollection<IhaleStatuDTO> IhaleStatu { get; set; }
		public IhaleTuruDTO IhaleTuru { get; set; }

    }
}
