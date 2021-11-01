using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InfoPQ.Models;

namespace InfoPQ.Data
{
    public class InfoPQContext : DbContext
    {
        public InfoPQContext (DbContextOptions<InfoPQContext> options)
            : base(options)
        {
        }

        public DbSet<InfoPQ.Models.Persona> Persona { get; set; }
    }
}
