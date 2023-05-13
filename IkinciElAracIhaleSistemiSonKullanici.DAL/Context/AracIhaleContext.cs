using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Context
{
    public class AracIhaleContext : DbContext
    {
        public AracIhaleContext()
        {
            
        }
        public AracIhaleContext(DbContextOptions<AracIhaleContext> opt) : base(opt)
        {

        }

    }
}
