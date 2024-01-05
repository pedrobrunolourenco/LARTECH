﻿using Lartech.Data.Mappings;
using Lartech.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lartech.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        }


        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMapping());
            modelBuilder.ApplyConfiguration(new TelefoneMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
