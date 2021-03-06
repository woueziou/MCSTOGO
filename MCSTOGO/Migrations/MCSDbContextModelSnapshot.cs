﻿// <auto-generated />
using MCSTOGO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MCSTOGO.Migrations
{
    [DbContext(typeof(MCSDbContext))]
    partial class MCSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MCSTOGO.Data.Entities.Photo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(12) CHARACTER SET utf8mb4")
                        .HasMaxLength(12);

                    b.Property<string>("DateAjout")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Etat")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PostId")
                        .HasColumnType("varchar(12) CHARACTER SET utf8mb4");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("MCSTOGO.Data.Entities.Post", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(12) CHARACTER SET utf8mb4")
                        .HasMaxLength(12);

                    b.Property<string>("DateAjout")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EtatVente")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Lieu")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NomPost")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Prix")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TypeContrat")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MCSTOGO.Data.Entities.Photo", b =>
                {
                    b.HasOne("MCSTOGO.Data.Entities.Post", "Post")
                        .WithMany("Photos")
                        .HasForeignKey("PostId");
                });
#pragma warning restore 612, 618
        }
    }
}
