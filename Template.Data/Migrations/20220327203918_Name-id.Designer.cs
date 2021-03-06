// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Data.Context;

namespace Template.Data.Migrations
{
    [DbContext(typeof(TemplateContext))]
    [Migration("20220327203918_Name-id")]
    partial class Nameid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Template.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0b214de7-8958-4956-8eed-28f9ba2c47c6"),
                            CreationDate = new DateTime(2022, 3, 27, 17, 39, 16, 594, DateTimeKind.Local).AddTicks(442),
                            Mail = "userDefault@example.com",
                            Name = "User Default",
                            UpdateDate = new DateTime(2022, 3, 27, 17, 39, 16, 598, DateTimeKind.Local).AddTicks(6482)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
