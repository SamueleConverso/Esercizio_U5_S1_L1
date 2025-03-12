﻿// <auto-generated />
using System;
using Esercizio_U5_S1_L1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Esercizio_U5_S1_L1.Migrations
{
    [DbContext(typeof(Esercizio_U5_S1_L1_EfCore))]
    partial class Esercizio_U5_S1_L1_EfCoreModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Esercizio_U5_S1_L1.Models.Book", b =>
                {
                    b.Property<Guid>("IdBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autore")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Disponibilità")
                        .HasColumnType("bit");

                    b.Property<int>("IdGenere")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdBook");

                    b.HasIndex("IdGenere");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Esercizio_U5_S1_L1.Models.Genere", b =>
                {
                    b.Property<int>("IdGenere")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGenere"));

                    b.Property<string>("TipoGenere")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdGenere");

                    b.ToTable("Generi");
                });

            modelBuilder.Entity("Esercizio_U5_S1_L1.Models.Book", b =>
                {
                    b.HasOne("Esercizio_U5_S1_L1.Models.Genere", "Genere")
                        .WithMany()
                        .HasForeignKey("IdGenere")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genere");
                });
#pragma warning restore 612, 618
        }
    }
}
