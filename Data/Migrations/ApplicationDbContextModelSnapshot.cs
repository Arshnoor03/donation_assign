﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using comp4976_assignment1.Data;

#nullable disable

namespace comp4976_assignment1.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2176da08-9a70-4221-afe0-5f26790503c4",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "d1eff987-dd82-4687-9201-e1caf815444a",
                            Name = "Finance",
                            NormalizedName = "FINANCE"
                        },
                        new
                        {
                            Id = "af30b332-4f02-4d34-8ac0-902939591ffa",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2cf3c54f-569f-4e15-9308-679b8cd879d9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5d1f36e8-dcbc-4796-b155-a1894c135727",
                            Email = "aa@aa.aa",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "AA@AA.AA",
                            NormalizedUserName = "AA@AA.AA",
                            PasswordHash = "AQAAAAIAAYagAAAAEEwFBfq3kQmgkKJeihJjPmnT/E3QMm/jWWum6H1hZNCEacRp6Laobh+4DCsaYrhiNQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "308416a0-104f-43da-8c27-dc8696e9cbcd",
                            TwoFactorEnabled = false,
                            UserName = "aa@aa.aa"
                        },
                        new
                        {
                            Id = "84652e1b-9187-4609-8df0-6e8c951ce906",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f87c72ea-33be-4b1e-ab2b-a774861b89dc",
                            Email = "mm@mm.mm",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MM@MM.MM",
                            NormalizedUserName = "MM@MM.MM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGxQrQFDeYINYqIn7wKaW3hDgwEgRlC8EyhGWJm/a8/xsRfx9vbxnh2sUOqxTf8V9g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ba6d257b-a401-4410-8b37-a414bb492da0",
                            TwoFactorEnabled = false,
                            UserName = "mm@mm.mm"
                        },
                        new
                        {
                            Id = "e2a5a270-9722-45e5-9081-0ad941b08a64",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6acb90aa-93d5-46e1-8229-29f2c92b1fa7",
                            Email = "ff@ff.ff",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "FF@FF.FF",
                            NormalizedUserName = "FF@FF.FF",
                            PasswordHash = "AQAAAAIAAYagAAAAEPr0rDcgSNWKEzYarhzCGuheGdUCXFFDa5Y1nqOXxKolmSPyNE3OYXD/nvkOREpF0A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "68302e01-2ba7-4962-8fb0-4123a63b732d",
                            TwoFactorEnabled = false,
                            UserName = "ff@ff.ff"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "2cf3c54f-569f-4e15-9308-679b8cd879d9",
                            RoleId = "2176da08-9a70-4221-afe0-5f26790503c4"
                        },
                        new
                        {
                            UserId = "84652e1b-9187-4609-8df0-6e8c951ce906",
                            RoleId = "af30b332-4f02-4d34-8ac0-902939591ffa"
                        },
                        new
                        {
                            UserId = "e2a5a270-9722-45e5-9081-0ad941b08a64",
                            RoleId = "d1eff987-dd82-4687-9201-e1caf815444a"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("comp4976_assignment1.Models.ContactList", b =>
                {
                    b.Property<int>("AccountNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("AccountNo");

                    b.ToTable("ContactList", (string)null);

                    b.HasData(
                        new
                        {
                            AccountNo = 1,
                            City = "New York",
                            Country = "USA",
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9300),
                            CreatedBy = "Seed",
                            Email = "johndoe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9370),
                            ModifiedBy = "Seed",
                            PostalCode = "V5T 2W8",
                            Street = "123 Main St"
                        },
                        new
                        {
                            AccountNo = 2,
                            City = "Richmond",
                            Country = "Canada",
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9380),
                            CreatedBy = "Seed",
                            Email = "sam@fox.com",
                            FirstName = "Sam",
                            LastName = "Fox",
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9380),
                            ModifiedBy = "Seed",
                            PostalCode = "V4F 1M7",
                            Street = "457 Fox Avenue"
                        },
                        new
                        {
                            AccountNo = 3,
                            City = "Delta",
                            Country = "Canada",
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9380),
                            CreatedBy = "Seed",
                            Email = "ann@day.com",
                            FirstName = "Ann",
                            LastName = "Day",
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9380),
                            ModifiedBy = "Seed",
                            PostalCode = "V6G 1M6",
                            Street = "231 River Road"
                        });
                });

            modelBuilder.Entity("comp4976_assignment1.Models.Donations", b =>
                {
                    b.Property<int>("TransId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountNo")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Amount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TransId");

                    b.HasIndex("AccountNo");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Donations", (string)null);

                    b.HasData(
                        new
                        {
                            TransId = 1,
                            AccountNo = 1,
                            Amount = 100f,
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9510),
                            CreatedBy = "Seed",
                            Date = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9510),
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9510),
                            ModifiedBy = "Seed",
                            Notes = "This is a first donation",
                            PaymentMethodId = 1,
                            TransactionTypeId = 1
                        },
                        new
                        {
                            TransId = 2,
                            AccountNo = 2,
                            Amount = 100f,
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9520),
                            CreatedBy = "Seed",
                            Date = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9520),
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9520),
                            ModifiedBy = "Seed",
                            Notes = "This is a second donation",
                            PaymentMethodId = 1,
                            TransactionTypeId = 2
                        },
                        new
                        {
                            TransId = 3,
                            AccountNo = 3,
                            Amount = 100f,
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9520),
                            CreatedBy = "Seed",
                            Date = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9520),
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9530),
                            ModifiedBy = "Seed",
                            Notes = "This is a third donation",
                            PaymentMethodId = 1,
                            TransactionTypeId = 3
                        });
                });

            modelBuilder.Entity("comp4976_assignment1.Models.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("PaymentMethodId");

                    b.ToTable("PaymentMethod", (string)null);

                    b.HasData(
                        new
                        {
                            PaymentMethodId = 1,
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9460),
                            CreatedBy = "Seed",
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9460),
                            ModifiedBy = "Seed",
                            Name = "Credit Card"
                        },
                        new
                        {
                            PaymentMethodId = 2,
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9470),
                            CreatedBy = "Seed",
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9470),
                            ModifiedBy = "Seed",
                            Name = "PayPal"
                        },
                        new
                        {
                            PaymentMethodId = 3,
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9470),
                            CreatedBy = "Seed",
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9470),
                            ModifiedBy = "Seed",
                            Name = "Debit Card"
                        });
                });

            modelBuilder.Entity("comp4976_assignment1.Models.TransactionType", b =>
                {
                    b.Property<int>("TransactionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("TransactionType", (string)null);

                    b.HasData(
                        new
                        {
                            TransactionTypeId = 1,
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9490),
                            CreatedBy = "Seed",
                            Description = "Donations made without any special purpose",
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9490),
                            ModifiedBy = "Seed",
                            Name = "General Donation"
                        },
                        new
                        {
                            TransactionTypeId = 2,
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9490),
                            CreatedBy = "Seed",
                            Description = "Donations made for homeless people",
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9490),
                            ModifiedBy = "Seed",
                            Name = "Food for homeless"
                        },
                        new
                        {
                            TransactionTypeId = 3,
                            Created = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9500),
                            CreatedBy = "Seed",
                            Description = "Donations for the purpose of upgrading the gym",
                            Modified = new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9500),
                            ModifiedBy = "Seed",
                            Name = "Repair of Gym"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("comp4976_assignment1.Models.Donations", b =>
                {
                    b.HasOne("comp4976_assignment1.Models.ContactList", "ContactList")
                        .WithMany()
                        .HasForeignKey("AccountNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("comp4976_assignment1.Models.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("comp4976_assignment1.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactList");

                    b.Navigation("PaymentMethod");

                    b.Navigation("TransactionType");
                });
#pragma warning restore 612, 618
        }
    }
}
