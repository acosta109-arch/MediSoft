﻿// <auto-generated />
using System;
using MediSoft.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediSoft.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240805065057_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("MediSoft.Models.Citas", b =>
                {
                    b.Property<int>("CitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DoctorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroSeguro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CitaId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("MediSoft.Models.DetalleDoctores", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiasDisponibilidad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DoctorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DoctoresDoctorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetalleId");

                    b.HasIndex("DoctoresDoctorId");

                    b.ToTable("DetalleDoctores");
                });

            modelBuilder.Entity("MediSoft.Models.Disponibilidades", b =>
                {
                    b.Property<int>("DisponibilidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Consultorio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DiasDisponibilidad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DoctorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HoraFin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HoraInicio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DisponibilidadId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Disponibilidades");
                });

            modelBuilder.Entity("MediSoft.Models.Doctores", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctores");
                });

            modelBuilder.Entity("MediSoft.Models.Noticias", b =>
                {
                    b.Property<int>("NoticiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("NoticiaId");

                    b.ToTable("Noticias");
                });

            modelBuilder.Entity("MediSoft.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Cedula = "12345678900",
                            Contrasena = "Admin12345@@",
                            CorreoElectronico = "administrador-sistema@gmail.com",
                            Direccion = "Ninguna",
                            NombreCompleto = "Administrador del sistema",
                            Rol = "Administrador",
                            Telefono = "8096680075",
                            Usuario = "administrador"
                        },
                        new
                        {
                            UsuarioId = 2,
                            Cedula = "98765432100",
                            Contrasena = "Jairo12345@@",
                            CorreoElectronico = "camiloacostajairo5@gmail.com",
                            Direccion = "Tenares",
                            NombreCompleto = "Jairo Camilo Acosta",
                            Rol = "Paciente",
                            Telefono = "8094275715",
                            Usuario = "jairo_camilo"
                        },
                        new
                        {
                            UsuarioId = 3,
                            Cedula = "11111111111",
                            Contrasena = "Erick12345@@",
                            CorreoElectronico = "erickfran99@gmail.com",
                            Direccion = "Villa Tapia",
                            NombreCompleto = "Erick Francisco Peña De Jesus",
                            Rol = "Paciente",
                            Telefono = "8292964961",
                            Usuario = "erick_pena"
                        });
                });

            modelBuilder.Entity("MediSoft.Models.Citas", b =>
                {
                    b.HasOne("MediSoft.Models.Doctores", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("MediSoft.Models.DetalleDoctores", b =>
                {
                    b.HasOne("MediSoft.Models.Doctores", null)
                        .WithMany("DetalleDoctores")
                        .HasForeignKey("DoctoresDoctorId");
                });

            modelBuilder.Entity("MediSoft.Models.Disponibilidades", b =>
                {
                    b.HasOne("MediSoft.Models.Doctores", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("MediSoft.Models.Doctores", b =>
                {
                    b.Navigation("DetalleDoctores");
                });
#pragma warning restore 612, 618
        }
    }
}