﻿// <auto-generated />
using System;
using GraphQLDotNet.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQLDotNet.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraphQLDotNet.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("035a3573-9ad4-43dc-9346-4142103e7827"),
                            Description = "Cash account for our users",
                            OwnerId = new Guid("ad22cd6c-6a61-492f-a91d-b119af9c9ffb"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("ca293563-21de-45c4-9e39-0c1df05fd3ee"),
                            Description = "Savings account for our users",
                            OwnerId = new Guid("56c69453-5c29-4b80-b93a-949a7f9f8b9e"),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("c0b5f6fe-c3ec-4cb0-9e80-913ccb705675"),
                            Description = "Income account for our users",
                            OwnerId = new Guid("56c69453-5c29-4b80-b93a-949a7f9f8b9e"),
                            Type = 3
                        });
                });

            modelBuilder.Entity("GraphQLDotNet.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ad22cd6c-6a61-492f-a91d-b119af9c9ffb"),
                            Address = "John Doe's address",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("56c69453-5c29-4b80-b93a-949a7f9f8b9e"),
                            Address = "Jane Doe's address",
                            Name = "Jane Doe"
                        });
                });

            modelBuilder.Entity("GraphQLDotNet.Entities.Account", b =>
                {
                    b.HasOne("GraphQLDotNet.Entities.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
