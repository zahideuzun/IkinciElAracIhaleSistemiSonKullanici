﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs
{
	public class IhaleTeklifVermeDTO
	{
		public int AracIhaleId { get; set; }
		public int UyeId { get; set; }
		public decimal TeklifEdilenFiyat { get; set; }
		public DateTime TeklifTarihi { get; set; }
		public bool OnaylandiMi { get; set; }
	}
}
