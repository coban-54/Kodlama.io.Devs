using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageTechnologies> LanguageTechnologies { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.
                       GetConnectionString("KodlamaioDevsConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(a =>
            {
                a.ToTable("Languages").HasKey(k => k.Id);
                a.Property(t => t.Id).HasColumnName("Id");
                a.Property(t => t.Name).HasColumnName("Name");
                a.HasMany(t => t.LanguageTechnologies);
            });
            modelBuilder.Entity<LanguageTechnologies>(a =>
            {
                a.ToTable("LanguageTechnologies").HasKey(k => k.Id);
                a.Property(t => t.Id).HasColumnName("Id");
                a.Property(t => t.LanguageId).HasColumnName("LanguageId");
                a.Property(t => t.TechnologyName).HasColumnName("TechnologyName");
                a.Property(t => t.TechnologyDescription).HasColumnName("TechnologyDescription");
                a.HasOne(t => t.Language);
            });

            Language[] languageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<Language>().HasData(languageEntitySeeds);
            LanguageTechnologies[] languageTechnologiesEntitySeeds = { new(1,1,".Net","Dotnet"), new(2,2, "WPF","") };
            modelBuilder.Entity<LanguageTechnologies>().HasData(languageTechnologiesEntitySeeds);
        }

    }
}
