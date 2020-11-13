﻿// <auto-generated />
using System;
using MayaBinance.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MayaBinance.DataAccess.Migrations
{
    [DbContext(typeof(MayaBinanceContext))]
    [Migration("20201113132415_change Modifier id")]
    partial class changeModifierid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MayaBinance.Domain.Identity.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailOrUserName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("SoftDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DeleterId");

                    b.HasIndex("ModifierId");

                    b.ToTable("Users", "identity");
                });

            modelBuilder.Entity("MayaBinance.Domain.Identity.Users.User", b =>
                {
                    b.HasOne("MayaBinance.Domain.Identity.Users.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MayaBinance.Domain.Identity.Users.User", "Deleter")
                        .WithMany()
                        .HasForeignKey("DeleterId");

                    b.HasOne("MayaBinance.Domain.Identity.Users.User", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.OwnsOne("MayaBinance.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasMaxLength(150)
                                .IsUnicode(true)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("Country")
                                .HasMaxLength(150)
                                .IsUnicode(true)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("Street")
                                .HasMaxLength(350)
                                .IsUnicode(true)
                                .HasColumnType("nvarchar(350)");

                            b1.Property<string>("ZipCode")
                                .HasMaxLength(14)
                                .IsUnicode(true)
                                .HasColumnType("nvarchar(14)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Creator");

                    b.Navigation("Deleter");

                    b.Navigation("Modifier");
                });
#pragma warning restore 612, 618
        }
    }
}
