﻿// <auto-generated />
using System;
using Domain.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(NeoBankContext))]
    [Migration("20230116075748_change-work-item")]
    partial class changeworkitem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Azure.WorkItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AreaPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IterationPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("TeamProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WorkItemCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkItemId")
                        .HasColumnType("int");

                    b.Property<int>("WorkItemTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WorkItem");
                });

            modelBuilder.Entity("Domain.Models.ServiceCallLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreationUserId")
                        .HasColumnType("int");

                    b.Property<string>("ErrorCode")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ErrorType")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ExpectedResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpectedStatus")
                        .HasColumnType("int");

                    b.Property<int?>("PBIId")
                        .HasColumnType("int");

                    b.Property<string>("RequestBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScenarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ServiceCallDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServiceCallStatus")
                        .HasColumnType("int");

                    b.Property<string>("ServiceCallUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("TestCaseId")
                        .HasColumnType("int");

                    b.Property<string>("WronResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isSuccess")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ServiceCallLog");
                });
#pragma warning restore 612, 618
        }
    }
}
