using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vuelos.Models
{
    public class VuelosContext : DbContext
    {
        public VuelosContext (DbContextOptions<VuelosContext> options)
            : base(options)
        {
        }

        public DbSet<Vuelos.Models.ClaseVuelo> ClaseVuelo { get; set; }
    }
}
