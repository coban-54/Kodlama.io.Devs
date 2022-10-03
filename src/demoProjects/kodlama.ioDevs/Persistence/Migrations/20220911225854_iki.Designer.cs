﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220911225854_iki")]
    partial class iki
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Languages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Java"
                        });
                });

            modelBuilder.Entity("Domain.Entities.LanguageTechnologies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LanguageId")
                        .HasColumnType("int")
                        .HasColumnName("LanguageId");

                    b.Property<string>("TechnologyDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TechnologyDescription");

                    b.Property<string>("TechnologyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TechnologyName");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("LanguageTechnologies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LanguageId = 1,
                            TechnologyDescription = "Dotnet",
                            TechnologyName = ".Net"
                        },
                        new
                        {
                            Id = 2,
                            LanguageId = 2,
                            TechnologyDescription = "",
                            TechnologyName = "WPF"
                        });
                });

            modelBuilder.Entity("Domain.Entities.LanguageTechnologies", b =>
                {
                    b.HasOne("Domain.Entities.Language", "Language")
                        .WithMany("LanguageTechnologies")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.Navigation("LanguageTechnologies");
                });
#pragma warning restore 612, 618
        }
    }
}
