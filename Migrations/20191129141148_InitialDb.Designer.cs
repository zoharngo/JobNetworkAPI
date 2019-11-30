﻿// <auto-generated />
using System;
using JobNetworkAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobNetworkAPI.Migrations
{
    [DbContext(typeof(JobContext))]
    [Migration("20191129141148_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobNetworkAPI.Data.Entities.Job", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discirption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("JobId");

                    b.HasIndex("JobTitleId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobNetworkAPI.Data.Entities.JobTitle", b =>
                {
                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.Property<string>("JobTitleText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobTitleId");

                    b.ToTable("JobTitles");
                });

            modelBuilder.Entity("JobNetworkAPI.Data.Entities.Job", b =>
                {
                    b.HasOne("JobNetworkAPI.Data.Entities.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}