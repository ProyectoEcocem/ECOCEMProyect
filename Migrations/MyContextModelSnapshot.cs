﻿// <auto-generated />
using System;
using ECOCEMProyect.migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECOCEMProyect.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ECOCEMProyect.Bascula", b =>
                {
                    b.Property<int>("BasculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BasculaId"));

                    b.HasKey("BasculaId");

                    b.ToTable("Basculas");
                });

            modelBuilder.Entity("ECOCEMProyect.Carga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaId")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SiloId")
                        .HasColumnType("integer");

                    b.Property<int>("TipoCementoId")
                        .HasColumnType("integer");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("integer");

                    b.Property<int>("VentaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VentaId");

                    b.ToTable("Cargas");
                });

            modelBuilder.Entity("ECOCEMProyect.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FabricaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaId")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SedeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("ECOCEMProyect.Descarga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaId")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SiloId")
                        .HasColumnType("integer");

                    b.Property<int>("TipoCementoId")
                        .HasColumnType("integer");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("integer");

                    b.Property<int>("compraId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("compraId");

                    b.ToTable("Descarga");
                });

            modelBuilder.Entity("ECOCEMProyect.EntidadCompradora", b =>
                {
                    b.Property<int>("EntidadCompradoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EntidadCompradoraId"));

                    b.HasKey("EntidadCompradoraId");

                    b.ToTable("EntidadCompradoras");
                });

            modelBuilder.Entity("ECOCEMProyect.Fabrica", b =>
                {
                    b.Property<int>("FabricaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FabricaId"));

                    b.HasKey("FabricaId");

                    b.ToTable("Fabricas");
                });

            modelBuilder.Entity("ECOCEMProyect.MedicionBascula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BasculaId")
                        .HasColumnType("integer");

                    b.Property<int?>("CargaId")
                        .HasColumnType("integer");

                    b.Property<int?>("DescargaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaId")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CargaId");

                    b.HasIndex("DescargaId");

                    b.ToTable("MedicionBascula");
                });

            modelBuilder.Entity("ECOCEMProyect.MedicionSilo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CargaId")
                        .HasColumnType("integer");

                    b.Property<int?>("DescargaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaId")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MedidorId")
                        .HasColumnType("integer");

                    b.Property<int>("Nivel")
                        .HasColumnType("integer");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.Property<int>("SiloId")
                        .HasColumnType("integer");

                    b.Property<int>("Volumen")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CargaId");

                    b.HasIndex("DescargaId");

                    b.ToTable("MedicionSilo");
                });

            modelBuilder.Entity("ECOCEMProyect.Medidor", b =>
                {
                    b.Property<int>("MedidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MedidorId"));

                    b.HasKey("MedidorId");

                    b.ToTable("Medidores");
                });

            modelBuilder.Entity("ECOCEMProyect.Sede", b =>
                {
                    b.Property<int>("SedeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SedeId"));

                    b.HasKey("SedeId");

                    b.ToTable("Sedes");
                });

            modelBuilder.Entity("ECOCEMProyect.Silo", b =>
                {
                    b.Property<int>("SiloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SiloId"));

                    b.HasKey("SiloId");

                    b.ToTable("Silos");
                });

            modelBuilder.Entity("ECOCEMProyect.TipoCemento", b =>
                {
                    b.Property<int>("TipoCementoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipoCementoId"));

                    b.HasKey("TipoCementoId");

                    b.ToTable("TipoCementos");
                });

            modelBuilder.Entity("ECOCEMProyect.Vehiculo", b =>
                {
                    b.Property<int>("VehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VehiculoId"));

                    b.HasKey("VehiculoId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("ECOCEMProyect.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IdEntidadCompradora")
                        .HasColumnType("integer");

                    b.Property<DateTime>("IdFecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdSede")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("ECOCEMProyect.Carga", b =>
                {
                    b.HasOne("ECOCEMProyect.Venta", "Venta")
                        .WithMany("Cargas")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("ECOCEMProyect.Descarga", b =>
                {
                    b.HasOne("ECOCEMProyect.Compra", "compra")
                        .WithMany("Descargas")
                        .HasForeignKey("compraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("compra");
                });

            modelBuilder.Entity("ECOCEMProyect.MedicionBascula", b =>
                {
                    b.HasOne("ECOCEMProyect.Carga", "Carga")
                        .WithMany("MedicionesBascula")
                        .HasForeignKey("CargaId");

                    b.HasOne("ECOCEMProyect.Descarga", "Descarga")
                        .WithMany("MedicionesBascula")
                        .HasForeignKey("DescargaId");

                    b.Navigation("Carga");

                    b.Navigation("Descarga");
                });

            modelBuilder.Entity("ECOCEMProyect.MedicionSilo", b =>
                {
                    b.HasOne("ECOCEMProyect.Carga", "Carga")
                        .WithMany("MedicionesSilo")
                        .HasForeignKey("CargaId");

                    b.HasOne("ECOCEMProyect.Descarga", "Descarga")
                        .WithMany("MedicionesSilo")
                        .HasForeignKey("DescargaId");

                    b.Navigation("Carga");

                    b.Navigation("Descarga");
                });

            modelBuilder.Entity("ECOCEMProyect.Carga", b =>
                {
                    b.Navigation("MedicionesBascula");

                    b.Navigation("MedicionesSilo");
                });

            modelBuilder.Entity("ECOCEMProyect.Compra", b =>
                {
                    b.Navigation("Descargas");
                });

            modelBuilder.Entity("ECOCEMProyect.Descarga", b =>
                {
                    b.Navigation("MedicionesBascula");

                    b.Navigation("MedicionesSilo");
                });

            modelBuilder.Entity("ECOCEMProyect.Venta", b =>
                {
                    b.Navigation("Cargas");
                });
#pragma warning restore 612, 618
        }
    }
}
