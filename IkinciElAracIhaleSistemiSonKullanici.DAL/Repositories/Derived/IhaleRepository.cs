using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived
{
    public class IhaleRepository : EfRepositoryBase<AracIhaleContext, Ihale>, IIhaleRepository
    {
        public IhaleRepository()
        {

        }
        public IhaleRepository(AracIhaleContext context) : base(context)
        {

        }


    }

}
