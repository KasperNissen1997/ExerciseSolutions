﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherForecastAPI.Data;

#nullable disable

namespace WeatherForecastAPI.Migrations
{
    [DbContext(typeof(WeatherForecastContext))]
    partial class WeatherForecastContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeatherForecastAPI.Models.ApiCallData", b =>
                {
                    b.Property<string>("ApiName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CallUrl")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CallDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CallJsonData")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApiName", "CallUrl", "CallDateTime");

                    b.ToTable("StoredApiCallData");
                });
#pragma warning restore 612, 618
        }
    }
}
