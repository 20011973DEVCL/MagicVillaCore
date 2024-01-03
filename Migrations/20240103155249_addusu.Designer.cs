﻿// <auto-generated />
using System;
using MagicVilla.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240103155249_addusu")]
    partial class addusu
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla.Models.NumeroVilla", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<string>("DetalleEspecial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("VillaNo");

                    b.HasIndex("VillaId");

                    b.ToTable("NumeroVillas");
                });

            modelBuilder.Entity("MagicVilla.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            Clave = "123",
                            FechaActualizacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NombreUsuario = "Danilo Alarcon Lopez"
                        });
                });

            modelBuilder.Entity("MagicVillaNetCore.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("int");

                    b.Property<double>("Tarifa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Detalle = "Tiene las tremendas Tetas",
                            FechaActualizacion = new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(390),
                            FechaCreacion = new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(340),
                            ImagenUrl = "",
                            MetrosCuadrados = 50,
                            Nombre = "Villa Fernanda",
                            Ocupantes = 5,
                            Tarifa = 200.0
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Detalle = "Tiene una Cintura y un Culo",
                            FechaActualizacion = new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(390),
                            FechaCreacion = new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(390),
                            ImagenUrl = "",
                            MetrosCuadrados = 70,
                            Nombre = "Villa Maira",
                            Ocupantes = 7,
                            Tarifa = 300.0
                        },
                        new
                        {
                            Id = 3,
                            Amenidad = "",
                            Detalle = "No se a cual de las 2 me Culiaria Primero",
                            FechaActualizacion = new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(400),
                            FechaCreacion = new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(400),
                            ImagenUrl = "",
                            MetrosCuadrados = 100,
                            Nombre = "Villa Fernanda y Maira",
                            Ocupantes = 7,
                            Tarifa = 500.0
                        },
                        new
                        {
                            Id = 3000,
                            Amenidad = "",
                            Detalle = "Culiando a la Fernanda todo el Dia",
                            FechaActualizacion = new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(400),
                            FechaCreacion = new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(400),
                            ImagenUrl = "",
                            MetrosCuadrados = 100,
                            Nombre = "Villa Danilo y Fernanda",
                            Ocupantes = 7,
                            Tarifa = 500.0
                        });
                });

            modelBuilder.Entity("MagicVilla.Models.NumeroVilla", b =>
                {
                    b.HasOne("MagicVillaNetCore.Models.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });
#pragma warning restore 612, 618
        }
    }
}
