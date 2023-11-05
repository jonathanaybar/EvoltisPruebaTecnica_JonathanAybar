using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PruebaTecnicaEvoltis_JonathanAybar.Models;
using System.Configuration;

namespace PruebaTecnicaEvoltis_JonathanAybar.Context
{
    public class EmpleadoDbContext : DbContext
    {
        public EmpleadoDbContext() : base(ConfigurationManager.ConnectionStrings["EvoltisPruebaTecnicaEntities"].ConnectionString)
        {
        }
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
        }
    }
}