using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizTower.IDP.Migrations
{
    /// <inheritdoc />
    public partial class InitialQuizTowerIdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Identity",
                columns: table => new
                {
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecurityCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecurityCodeExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Identity",
                columns: table => new
                {
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Identity",
                columns: table => new
                {
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProviderIdentityKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserSecrets",
                schema: "Identity",
                columns: table => new
                {
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserSecrets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "UserName" },
                values: new object[,]
                {
                    { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), true, "71c8d265-9eac-4fcf-be1f-c6b7ecd655ac", "david@someprovider.com", "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d860efca-22d9-47fd-8249-791ba61b07c7", "David" },
                    { new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), true, "8315eadb-caa7-452d-8c46-bd15d1791c7b", "emma@someprovider.com", "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "Emma" },
                    { new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), true, "2149b3ed-d54d-47a7-afb1-8cde7e7a075a", "admin@admin.com", "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B8C91EF2-7C41-4561-A323-A73B8F25F686", "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("43613a6e-f767-4ca2-994f-b953dcbf5006"), "4fd60a1c-0275-4e55-8478-f3ea020a04ab", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("47b1d199-e57b-4cbe-b1e2-8d824e043c4d"), "526a990e-debf-4de9-9143-869b6751e3b1", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("72eb129c-d954-4211-8b94-e3d594705499"), "3d0f46ef-289c-4472-b570-b2a343b18a38", "given_name", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Admin" },
                    { new Guid("7a59a12a-aaed-4799-862a-fddd4fb4f521"), "69e21ea4-d751-4273-9e51-94fe4a5f95f6", "family_name", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Flagg" },
                    { new Guid("913474cd-d936-4f9d-8431-2aaca8a95dff"), "43d5b0c9-54d6-45ac-a270-c0cc466876a2", "role", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Owner" },
                    { new Guid("9b8b95bd-2353-4acf-9d9a-3d0f62adde2f"), "63027ba2-c9d8-4c21-8439-9f5edcf0915c", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "QuizMaster" },
                    { new Guid("a489adef-e696-4ea8-afe9-0f60a6a2b70c"), "445c1570-db9c-4ef1-a429-f2e7fb924786", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("a536485b-56ad-41b4-aaa5-1310d2e9b59d"), "1b135caa-3f69-4232-9509-a6abed81bbc3", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("ab35d664-e2be-4e2e-8c0b-6a79845c0126"), "ac4fed47-925e-4a15-a023-c68c11512dfb", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("b25df510-2891-4895-94ba-019995de222c"), "742cb02a-4e9c-4545-a438-fa906284edf0", "country", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "nl" },
                    { new Guid("bd7a3177-49f5-464f-b399-b1958e85463d"), "2e8e47f6-561c-450a-b139-ed268ce85f77", "role", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "SecurityAdmin" },
                    { new Guid("e7e73b50-a546-4dd7-98a6-f04aeae04c3a"), "7d2ef7a7-ec2f-40fb-8ab1-cd0c40ad53f5", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Player" },
                    { new Guid("f6f9a848-6ae4-483e-b4c5-d3c56c5d5bf8"), "7e96ebba-e9cc-42ea-ba09-32ab249ac874", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("fb79ff32-d67c-4424-b358-dabc38a46922"), "7309b04d-936b-4b51-ae9d-f2a6ba1c825d", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("fd50dee5-cddd-4d6c-b3b4-533eb2c4ceb9"), "e26a54a3-a580-444f-b41e-fd6fa7e4b090", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Identity",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Identity",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Subject",
                schema: "Identity",
                table: "AspNetUsers",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                schema: "Identity",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserSecrets_UserId",
                schema: "Identity",
                table: "AspNetUserSecrets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserSecrets",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Identity");
        }
    }
}
