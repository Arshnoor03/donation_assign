using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace comp4976_assignment1.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactList",
                columns: table => new
                {
                    AccountNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactList", x => x.AccountNo);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    TransactionTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.TransactionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    TransId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AccountNo = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<float>(type: "REAL", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.TransId);
                    table.ForeignKey(
                        name: "FK_Donations_ContactList_AccountNo",
                        column: x => x.AccountNo,
                        principalTable: "ContactList",
                        principalColumn: "AccountNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donations_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donations_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "TransactionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2176da08-9a70-4221-afe0-5f26790503c4", null, "Admin", "ADMIN" },
                    { "af30b332-4f02-4d34-8ac0-902939591ffa", null, "Member", "MEMBER" },
                    { "d1eff987-dd82-4687-9201-e1caf815444a", null, "Finance", "FINANCE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2cf3c54f-569f-4e15-9308-679b8cd879d9", 0, "5d1f36e8-dcbc-4796-b155-a1894c135727", "aa@aa.aa", true, false, null, "AA@AA.AA", "AA@AA.AA", "AQAAAAIAAYagAAAAEEwFBfq3kQmgkKJeihJjPmnT/E3QMm/jWWum6H1hZNCEacRp6Laobh+4DCsaYrhiNQ==", null, false, "308416a0-104f-43da-8c27-dc8696e9cbcd", false, "aa@aa.aa" },
                    { "84652e1b-9187-4609-8df0-6e8c951ce906", 0, "f87c72ea-33be-4b1e-ab2b-a774861b89dc", "mm@mm.mm", true, false, null, "MM@MM.MM", "MM@MM.MM", "AQAAAAIAAYagAAAAEGxQrQFDeYINYqIn7wKaW3hDgwEgRlC8EyhGWJm/a8/xsRfx9vbxnh2sUOqxTf8V9g==", null, false, "ba6d257b-a401-4410-8b37-a414bb492da0", false, "mm@mm.mm" },
                    { "e2a5a270-9722-45e5-9081-0ad941b08a64", 0, "6acb90aa-93d5-46e1-8229-29f2c92b1fa7", "ff@ff.ff", true, false, null, "FF@FF.FF", "FF@FF.FF", "AQAAAAIAAYagAAAAEPr0rDcgSNWKEzYarhzCGuheGdUCXFFDa5Y1nqOXxKolmSPyNE3OYXD/nvkOREpF0A==", null, false, "68302e01-2ba7-4962-8fb0-4123a63b732d", false, "ff@ff.ff" }
                });

            migrationBuilder.InsertData(
                table: "ContactList",
                columns: new[] { "AccountNo", "City", "Country", "Created", "CreatedBy", "Email", "FirstName", "LastName", "Modified", "ModifiedBy", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "New York", "USA", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9300), "Seed", "johndoe@example.com", "John", "Doe", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9370), "Seed", "V5T 2W8", "123 Main St" },
                    { 2, "Richmond", "Canada", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9380), "Seed", "sam@fox.com", "Sam", "Fox", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9380), "Seed", "V4F 1M7", "457 Fox Avenue" },
                    { 3, "Delta", "Canada", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9380), "Seed", "ann@day.com", "Ann", "Day", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9380), "Seed", "V6G 1M6", "231 River Road" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "PaymentMethodId", "Created", "CreatedBy", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9460), "Seed", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9460), "Seed", "Credit Card" },
                    { 2, new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9470), "Seed", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9470), "Seed", "PayPal" },
                    { 3, new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9470), "Seed", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9470), "Seed", "Debit Card" }
                });

            migrationBuilder.InsertData(
                table: "TransactionType",
                columns: new[] { "TransactionTypeId", "Created", "CreatedBy", "Description", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9490), "Seed", "Donations made without any special purpose", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9490), "Seed", "General Donation" },
                    { 2, new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9490), "Seed", "Donations made for homeless people", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9490), "Seed", "Food for homeless" },
                    { 3, new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9500), "Seed", "Donations for the purpose of upgrading the gym", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9500), "Seed", "Repair of Gym" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2176da08-9a70-4221-afe0-5f26790503c4", "2cf3c54f-569f-4e15-9308-679b8cd879d9" },
                    { "af30b332-4f02-4d34-8ac0-902939591ffa", "84652e1b-9187-4609-8df0-6e8c951ce906" },
                    { "d1eff987-dd82-4687-9201-e1caf815444a", "e2a5a270-9722-45e5-9081-0ad941b08a64" }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "TransId", "AccountNo", "Amount", "Created", "CreatedBy", "Date", "Modified", "ModifiedBy", "Notes", "PaymentMethodId", "TransactionTypeId" },
                values: new object[,]
                {
                    { 1, 1, 100f, new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9510), "Seed", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9510), new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9510), "Seed", "This is a first donation", 1, 1 },
                    { 2, 2, 100f, new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9520), "Seed", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9520), new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9520), "Seed", "This is a second donation", 1, 2 },
                    { 3, 3, 100f, new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9520), "Seed", new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9520), new DateTime(2023, 10, 15, 22, 32, 53, 41, DateTimeKind.Local).AddTicks(9530), "Seed", "This is a third donation", 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_AccountNo",
                table: "Donations",
                column: "AccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_PaymentMethodId",
                table: "Donations",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_TransactionTypeId",
                table: "Donations",
                column: "TransactionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ContactList");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "TransactionType");
        }
    }
}
