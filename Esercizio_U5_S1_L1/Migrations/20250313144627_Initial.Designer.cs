﻿// <auto-generated />
using System;
using Esercizio_U5_S1_L1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Esercizio_U5_S1_L1.Migrations
{
    [DbContext(typeof(Esercizio_U5_S1_L1_EfCore))]
    [Migration("20250313144627_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
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

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Esercizio_U5_S1_L1.Models.Prestito", b =>
                {
                    b.Property<int>("IdPrestito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrestito"));

                    b.Property<DateTime>("DataPrestito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataRestituzione")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasComputedColumnSql("DATEADD(day, 10, DataPrestito)");

                    b.Property<Guid>("IdBook")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdPrestito");

                    b.HasIndex("IdBook");

                    b.ToTable("Prestiti");
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

            modelBuilder.Entity("Esercizio_U5_S1_L1.Models.Prestito", b =>
                {
                    b.HasOne("Esercizio_U5_S1_L1.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
