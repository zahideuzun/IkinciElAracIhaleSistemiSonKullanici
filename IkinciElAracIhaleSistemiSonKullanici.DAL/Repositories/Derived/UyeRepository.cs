﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.EF;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived
{
    public class UyeRepository : EfRepositoryBase<AracIhaleContext, Uye>, IUyeRepository
    {
        public UyeRepository()
        {
            
        }
        public UyeRepository(AracIhaleContext context) : base(context)
        {

        }

        
    }
}