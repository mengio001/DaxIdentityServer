using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizTower.IDP.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class InitialApplicationDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecurityCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecurityCodeExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProviderIdentityKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSecrets",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSecrets_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "UserName" },
                values: new object[,]
                {
                    { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), true, "ceb4f9de-88fa-421a-83bb-e59ae01458f8", "david@someprovider.com", "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d860efca-22d9-47fd-8249-791ba61b07c7", "David" },
                    { new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), true, "bd2b6534-5c0e-4a72-ac27-0787d10bf26b", "emma@someprovider.com", "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "Emma" },
                    { new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), true, "7378a412-d481-4da8-ac46-77de95e03859", "admin@admin.com", "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B8C91EF2-7C41-4561-A323-A73B8F25F686", "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("0506f580-6a00-4b7c-a6b7-6fb7acb9077b"), "5c6d656b-3ad3-4e0e-9a41-f82d5645644d", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Player" },
                    { new Guid("0559b1ba-51b5-43c9-a25c-224583e97e38"), "75bac4d2-91ee-4d91-bdc7-7a44bacabd85", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "QuizMaster" },
                    { new Guid("148524c2-4095-42e0-917b-33268e7741a6"), "6983dfb3-6819-44ea-b659-5ed17f5c9d1d", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("1635554c-790f-4b8c-a4ed-def3ee3dbd4e"), "d282c098-801d-40a7-bd38-4294bebdf831", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("3eb4f1d0-a07e-462b-8a8b-aa574e17f3ff"), "12a3edfd-7514-4e6c-a1de-e923a7e43677", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("44d12e4a-3c29-4200-a341-0923d9c89855"), "8647b7ba-c8fc-4a99-8b48-6bab02605b64", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("5b72aed3-1b26-41eb-a5e6-129b75330681"), "45ee0fdf-eb4f-4f3a-8c5b-bf11a939cb5a", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("604287f2-e37b-42b2-86a5-291f3b9e50d4"), "b98f552e-2db6-45f4-90e5-d73194c157c8", "family_name", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Flagg" },
                    { new Guid("7196300d-a1fc-4f03-9508-9a97c26d0dfd"), "8a6b5fff-dc5f-46a2-8ef0-a1bccfe59198", "country", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "nl" },
                    { new Guid("7acce744-a902-4f34-9ab9-92bd6354cc10"), "039b49fd-a8a2-4ea2-b5df-2c3fd6a0cad6", "given_name", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Admin" },
                    { new Guid("7e609aff-85f6-4962-9bfe-3c85d90ecb7c"), "cc5e6704-f055-4627-b472-90c547a73c4a", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("8399b86b-92dd-41c4-9da6-dedb0d6acd93"), "86b376b8-577c-4a78-ab2c-cb3acfbba53e", "role", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "SecurityAdmin" },
                    { new Guid("b8e60610-32a4-4253-8a4d-b1782a26a160"), "f5d27ec9-bc41-4a2c-8ed5-85a5df32f705", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("c2bd0a20-5d0b-4bff-a4d8-1da5e944d4cc"), "6975919b-ded6-4a42-b3b5-c877bfe46b2f", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("e0a22e93-d8aa-4073-8a92-713ab26b7aa9"), "d78bc5bc-a0aa-424a-a23d-8e3f72032444", "role", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Owner" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subject",
                schema: "Identity",
                table: "Users",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "Identity",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserSecrets_UserId",
                schema: "Identity",
                table: "UserSecrets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserSecrets",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");
        }
    }
}
