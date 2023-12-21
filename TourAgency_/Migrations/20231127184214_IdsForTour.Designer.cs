﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TourAgency_.Models.Entities;
#nullable disable

namespace TourAgency_
{
    [DbContext(typeof(TourAgencyContext))]
    [Migration("20231127184214_IdsForTour")]
    partial class IdsForTour
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DomainLevel.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("InternationalPassportNumber")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DomainLevel.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("ConclusionDate")
                        .HasColumnType("date");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalCost")
                        .HasColumnType("integer");

                    b.Property<int>("TourId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TourId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("DomainLevel.Direction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("DomainLevel.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContractCount")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DomainLevel.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContractId")
                        .HasColumnType("integer");

                    b.Property<string>("Reply")
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("StatusId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("DomainLevel.RequestStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RequestStatuses");
                });

            modelBuilder.Entity("DomainLevel.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("ArrivalDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DepartureDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DirectionId")
                        .HasColumnType("integer");

                    b.Property<int>("HotelStarsCount")
                        .HasColumnType("integer");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("TourOperatorId")
                        .HasColumnType("integer");

                    b.Property<int>("TransportTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DirectionId");

                    b.HasIndex("TourOperatorId");

                    b.HasIndex("TransportTypeId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("DomainLevel.TourOperator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TourOperators");
                });

            modelBuilder.Entity("DomainLevel.TransportTypeName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TransportTypes");
                });

            modelBuilder.Entity("DomainLevel.Contract", b =>
                {
                    b.HasOne("DomainLevel.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLevel.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLevel.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("DomainLevel.Request", b =>
                {
                    b.HasOne("DomainLevel.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLevel.RequestStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DomainLevel.Tour", b =>
                {
                    b.HasOne("DomainLevel.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLevel.TourOperator", "TourOperator")
                        .WithMany()
                        .HasForeignKey("TourOperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLevel.TransportTypeName", "TransportTypeName")
                        .WithMany()
                        .HasForeignKey("TransportTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direction");

                    b.Navigation("TourOperator");

                    b.Navigation("TransportTypeName");
                });
#pragma warning restore 612, 618
        }
    }
}
