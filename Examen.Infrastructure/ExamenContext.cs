
using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class ExamenContext:DbContext
    {
        public DbSet<Activite> activites { get; set; }

        public DbSet<Client> clients { get; set; }

        public DbSet<Conseiller> conseillers { get; set; }

        public DbSet<Pack> packs { get; set; }

        public DbSet<Reservation> reservations { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); 

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                       Initial Catalog= BDBDBDB;
                       Integrated Security=true;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //si en utilisant fluent Api 
           // modelBuilder.Entity<Activite>().OwnsOne(activ => activ.Zone);

            //////////////////////////

            modelBuilder.Entity<Reservation>().HasOne(reserv => reserv.lemsi)
                                .WithMany(client => client.lemsiii)
                                .HasForeignKey(resrv => resrv.ClientFk);

            modelBuilder.Entity<Reservation>().HasOne(reserv => reserv.Pack)
                    .WithMany(pack => pack.Reservations)
                    .HasForeignKey(resrv => resrv.PackFk);

            /////////////////////////

            modelBuilder.Entity<Reservation>().HasKey(r => new { r.ClientFk, r.PackFk, r.DateReservation });
            base.OnModelCreating(modelBuilder);


            /////////////////////////

            modelBuilder.Entity<Client>().HasOne(cl => cl.conseiller)
                                .WithMany(con => con.clients)
                                .HasForeignKey(cl => cl.ConseillerFk)
                                .OnDelete(DeleteBehavior.Cascade);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<int>().HaveMaxLength(15);
            base.ConfigureConventions(configurationBuilder);

        }
    }
}
