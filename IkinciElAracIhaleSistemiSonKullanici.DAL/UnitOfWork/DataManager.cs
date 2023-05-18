using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.UnitOfWork
{
    public class DataManager
    {
        public AracIhaleContext Context { get; }

        public DataManager()
        {
            Context = new AracIhaleContext();
        }

        public IUyeRepository GetUyeRepository()
        {
            return new UyeRepository(Context);
        }
        public IIhaleRepository GetIhaleRepository()
        {
            return new IhaleRepository(Context);
        }

        public IAracTeklifRepository GetAracTeklifRepository()
        {
	        return new AracTeklifRepository(Context);
        }

		public void MySaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
