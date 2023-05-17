using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs
{
    public class UyeSessionDTO
    {
        public int UyeId { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public int UyeTuruId { get; set; }
        public int RolId { get; set; }
    }
}
