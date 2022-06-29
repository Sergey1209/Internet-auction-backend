﻿// <auto-generated />
using System;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(InternetAuctionDbContext))]
    [Migration("20220629110449_e")]
    partial class e
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BetValue")
                        .HasColumnType("money");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("InitialPrice")
                        .HasColumnType("money");

                    b.Property<int>("LotId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LotId")
                        .IsUnique();

                    b.ToTable("Auctions");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            BetValue = 22m,
                            CustomerId = 1,
                            Deadline = new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 22m,
                            LotId = 1,
                            OperationDate = new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 102,
                            BetValue = 32m,
                            CustomerId = 1,
                            Deadline = new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 32m,
                            LotId = 2,
                            OperationDate = new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 103,
                            BetValue = 42m,
                            CustomerId = 1,
                            Deadline = new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 42m,
                            LotId = 3,
                            OperationDate = new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 104,
                            BetValue = 52m,
                            CustomerId = 1,
                            Deadline = new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 52m,
                            LotId = 4,
                            OperationDate = new DateTime(2021, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 105,
                            BetValue = 62m,
                            CustomerId = 1,
                            Deadline = new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 62m,
                            LotId = 5,
                            OperationDate = new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 106,
                            BetValue = 72m,
                            CustomerId = 1,
                            Deadline = new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 72m,
                            LotId = 6,
                            OperationDate = new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 107,
                            BetValue = 82m,
                            CustomerId = 2,
                            Deadline = new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 82m,
                            LotId = 7,
                            OperationDate = new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 108,
                            BetValue = 92m,
                            CustomerId = 2,
                            Deadline = new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 92m,
                            LotId = 8,
                            OperationDate = new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 109,
                            BetValue = 102m,
                            CustomerId = 2,
                            Deadline = new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 102m,
                            LotId = 9,
                            OperationDate = new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 110,
                            BetValue = 112m,
                            CustomerId = 2,
                            Deadline = new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 112m,
                            LotId = 10,
                            OperationDate = new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 111,
                            BetValue = 122m,
                            CustomerId = 2,
                            Deadline = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 122m,
                            LotId = 11,
                            OperationDate = new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 112,
                            BetValue = 10m,
                            CustomerId = 2,
                            Deadline = new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitialPrice = 10m,
                            LotId = 12,
                            OperationDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Data.Entities.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "lotcategory1.png"
                        },
                        new
                        {
                            Id = 2,
                            Name = "lotcategory2.png"
                        },
                        new
                        {
                            Id = 3,
                            Name = "lotcategory3.png"
                        },
                        new
                        {
                            Id = 11,
                            Name = "lot1.jpg"
                        },
                        new
                        {
                            Id = 12,
                            Name = "lot2.jpg"
                        },
                        new
                        {
                            Id = 13,
                            Name = "lot3.jpg"
                        });
                });

            modelBuilder.Entity("Data.Entities.Lot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024)
                        .IsUnicode(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(true);

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Lots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            Description = "Description 1",
                            Name = "lot 1",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Description 2",
                            Name = "lot 2",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Description 3",
                            Name = "lot 3",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Description 4",
                            Name = "lot 4",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Description 5",
                            Name = "lot 5",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Description 6",
                            Name = "lot 6",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "Description 7",
                            Name = "lot 7",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Description = "Description 8",
                            Name = "lot 8",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            Description = "Description 9",
                            Name = "lot 9",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Description = "Description 10",
                            Name = "lot 10",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 2,
                            Description = "Description 11",
                            Name = "lot 11",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 2,
                            Description = "Description 13",
                            Name = "lot 13",
                            OwnerId = 1
                        });
                });

            modelBuilder.Entity("Data.Entities.LotCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FileId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("FileId")
                        .IsUnique()
                        .HasFilter("[FileId] IS NOT NULL");

                    b.ToTable("LotCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FileId = 1,
                            Name = "Miscellaneous"
                        },
                        new
                        {
                            Id = 2,
                            FileId = 2,
                            Name = "Category 2"
                        },
                        new
                        {
                            Id = 3,
                            FileId = 3,
                            Name = "Category 3"
                        });
                });

            modelBuilder.Entity("Data.Entities.LotImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<int>("LotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("LotId", "FileId");

                    b.ToTable("LotImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FileId = 11,
                            LotId = 1
                        },
                        new
                        {
                            Id = 2,
                            FileId = 12,
                            LotId = 1
                        },
                        new
                        {
                            Id = 3,
                            FileId = 13,
                            LotId = 2
                        });
                });

            modelBuilder.Entity("Data.Entities.Auction", b =>
                {
                    b.HasOne("Data.Entities.Lot", "Lot")
                        .WithOne("Auction")
                        .HasForeignKey("Data.Entities.Auction", "LotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Lot", b =>
                {
                    b.HasOne("Data.Entities.LotCategory", "Category")
                        .WithMany("Lots")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.LotCategory", b =>
                {
                    b.HasOne("Data.Entities.File", "File")
                        .WithOne("LotCategory")
                        .HasForeignKey("Data.Entities.LotCategory", "FileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.LotImage", b =>
                {
                    b.HasOne("Data.Entities.File", "File")
                        .WithMany("LotImages")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Lot", "Lot")
                        .WithMany("LotImages")
                        .HasForeignKey("LotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
