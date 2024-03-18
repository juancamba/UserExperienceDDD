using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Domain;

namespace UserExperience.Infra.Persistence.DatabaseContext
{
    public class WEDatabaseContext : DbContext
    {
        public WEDatabaseContext(DbContextOptions<WEDatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Workingexperience> Workingexperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // esto es para que no tengamos que estar poniendo las configuraciones de las entidades en el OnModelCreating
            // sepramos por entidades en /Configurations
            // para crear datos en bd en momento de creacion
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WEDatabaseContext).Assembly);




            base.OnModelCreating(modelBuilder);
        }

    }
}
