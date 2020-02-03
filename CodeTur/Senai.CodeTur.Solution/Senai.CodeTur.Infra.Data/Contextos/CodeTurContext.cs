using System;
using Microsoft.EntityFrameworkCore;
using Senai.CodeTur.Dominio.Entidades;

namespace Senai.CodeTur.Infra.Data.Contextos
{
    public class CodeTurContext : DbContext
    {
        //Declaração dos DbSets do contexto
        public DbSet<UsuarioDominio> Usuarios { get; set; }
        public DbSet<PacoteDominio> Pacotes { get; set; }

        //Metodo construtor passando como parametros as opções do Contexto
        public CodeTurContext(DbContextOptions<CodeTurContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Verifica se o contexto já não esta configurado, caso não eseja utiliza a string de conexão abaixo
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS3TT;Initial Catalog=CodeTurManha;integrated security=true");
            }

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
