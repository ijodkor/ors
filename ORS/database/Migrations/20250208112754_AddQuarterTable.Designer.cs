﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ORS.Database;

#nullable disable

namespace ORS.database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20250208112754_AddQuarterTable")]
    partial class AddQuarterTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ORS.Apps.Regions.Models.Quarter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Dictionary<string, string>>("Names")
                        .IsRequired()
                        .HasColumnType("jsonb")
                        .HasColumnName("names");

                    b.Property<int>("Order")
                        .HasColumnType("integer")
                        .HasColumnName("ord");

                    b.Property<int>("RegionId")
                        .HasColumnType("integer")
                        .HasColumnName("region_id");

                    b.Property<short>("Type")
                        .HasColumnType("smallint")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("quarters", "public");
                });

            modelBuilder.Entity("ORS.Apps.Regions.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("NameRu")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name_ru");

                    b.Property<string>("NameUzk")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name_uzk");

                    b.Property<string>("NameUzl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name_uzl");

                    b.Property<int>("Order")
                        .HasColumnType("integer")
                        .HasColumnName("ord");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer")
                        .HasColumnName("parent_id");

                    b.HasKey("Id");

                    b.ToTable("regions", "public");
                });
#pragma warning restore 612, 618
        }
    }
}
