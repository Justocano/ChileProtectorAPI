using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using WebApiComunas.Models;
using System.Drawing;

namespace WebApiComunas.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Comunas> Comunas  { get; set; }
        public DbSet<Regiones> Regiones { get; set; }
        
    }
}
