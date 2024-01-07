﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pmesp.Infrastructure.Context;

#nullable disable

namespace pmesp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240107221314_tableSocialMedia")]
    partial class tableSocialMedia
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("pmesp.Domain.Entities.Addresses.Address", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.AssociateAddress.AssociateAddresses", b =>
                {
                    b.Property<string>("AddressesId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BanditsId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("AddressesId", "BanditsId");

                    b.HasIndex("BanditsId");

                    b.ToTable("AddressBandit");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.Bandits.Bandit", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("ChainRegistration")
                        .HasColumnType("longtext");

                    b.Property<string>("CrimeFunction")
                        .HasColumnType("longtext");

                    b.Property<string>("CriminalRG")
                        .HasColumnType("longtext");

                    b.Property<string>("CriminalSituation")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("ExtensionPhoto")
                        .HasColumnType("longtext");

                    b.Property<float?>("Height")
                        .HasColumnType("float");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nationality")
                        .HasColumnType("longtext");

                    b.Property<string>("Naturalness")
                        .HasColumnType("longtext");

                    b.Property<string>("ORCRIM")
                        .HasColumnType("longtext");

                    b.Property<string>("OperationPhone")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("PixCPF")
                        .HasColumnType("longtext");

                    b.Property<string>("PixEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("PixPhone")
                        .HasColumnType("longtext");

                    b.Property<string>("PrincipalPhoto")
                        .HasColumnType("longtext");

                    b.Property<string>("Profession")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext");

                    b.Property<float?>("Weight")
                        .HasColumnType("float");

                    b.Property<string>("WhatsApp")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Bandits");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.Cops.Cop", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Graduation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("Cops");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.Guns.Gun", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BanditId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Brand")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Caliber")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("National")
                        .HasColumnType("longtext");

                    b.Property<string>("Numeration")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<bool?>("Shaved")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("BanditId");

                    b.ToTable("Guns");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.RGs.RG", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BanditId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("SenderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BanditId");

                    b.ToTable("RGs");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.SocialMedias.SocialMedia", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BanditId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<string>("Owner")
                        .HasColumnType("longtext");

                    b.Property<string>("Platform")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BanditId");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.Tattoos.Tattoo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BanditId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BodyLocation")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("Colored")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BanditId");

                    b.ToTable("Tattoos");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.Vehicles.Vehicle", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BanditId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("CPFowner")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("BanditId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.AssociateAddress.AssociateAddresses", b =>
                {
                    b.HasOne("pmesp.Domain.Entities.Addresses.Address", "Address")
                        .WithMany("Bandits")
                        .HasForeignKey("AddressesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pmesp.Domain.Entities.Bandits.Bandit", "Bandit")
                        .WithMany("Addresses")
                        .HasForeignKey("BanditsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Bandit");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.Guns.Gun", b =>
                {
                    b.HasOne("pmesp.Domain.Entities.Bandits.Bandit", "Bandit")
                        .WithMany("Guns")
                        .HasForeignKey("BanditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bandit");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.RGs.RG", b =>
                {
                    b.HasOne("pmesp.Domain.Entities.Bandits.Bandit", "Bandit")
                        .WithMany("rGs")
                        .HasForeignKey("BanditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bandit");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.SocialMedias.SocialMedia", b =>
                {
                    b.HasOne("pmesp.Domain.Entities.Bandits.Bandit", "Bandit")
                        .WithMany("SocialMedias")
                        .HasForeignKey("BanditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bandit");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.Tattoos.Tattoo", b =>
                {
                    b.HasOne("pmesp.Domain.Entities.Bandits.Bandit", "Bandit")
                        .WithMany("Tattoos")
                        .HasForeignKey("BanditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bandit");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.Vehicles.Vehicle", b =>
                {
                    b.HasOne("pmesp.Domain.Entities.Bandits.Bandit", "Bandit")
                        .WithMany("Vehicles")
                        .HasForeignKey("BanditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bandit");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.Addresses.Address", b =>
                {
                    b.Navigation("Bandits");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.Bandits.Bandit", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Guns");

                    b.Navigation("SocialMedias");

                    b.Navigation("Tattoos");

                    b.Navigation("Vehicles");

                    b.Navigation("rGs");
                });
#pragma warning restore 612, 618
        }
    }
}