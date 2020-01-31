using Microsoft.EntityFrameworkCore;
using Senai.CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senai.CodeTur.Infra.Data.Contextos
{
    public class CodeTurContext : DbContext
    {
        public DbSet<UsuarioDominio> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.\\SQLEXPRESS3TT; User ID = sa; Password = ********; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioDominio>().HasData(
                new UsuarioDominio() {
                                    Id =1,
                                    Nome = "Rafael Pieri",
                                    Email = "admin@codetur.com",
                                    Senha = "Codetur@132",
                                    Tipo = "Administrador"
                }                                
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}