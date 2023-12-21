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
    [Migration("20231220221104_implementingBanditAddresses")]
    partial class implementingBanditAddresses
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

            modelBuilder.Entity("pmesp.Domain.Entities.BanditAddresses.BanditAddress", b =>
                {
                    b.Property<string>("BanditId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AddressId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("BanditId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("BanditAddresses");
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

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<float?>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext");

                    b.Property<float?>("Weight")
                        .HasColumnType("float");

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

            modelBuilder.Entity("pmesp.Domain.Entities.BanditAddresses.BanditAddress", b =>
                {
                    b.HasOne("pmesp.Domain.Entities.Addresses.Address", "Address")
                        .WithMany("banditAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pmesp.Domain.Entities.Bandits.Bandit", "Bandit")
                        .WithMany("banditAddresses")
                        .HasForeignKey("BanditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

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

            modelBuilder.Entity("pmesp.Domain.Entities.Addresses.Address", b =>
                {
                    b.Navigation("banditAddresses");
                });

            modelBuilder.Entity("pmesp.Domain.Entities.Bandits.Bandit", b =>
                {
                    b.Navigation("banditAddresses");

                    b.Navigation("rGs");
                });
#pragma warning restore 612, 618
        }
    }
}
