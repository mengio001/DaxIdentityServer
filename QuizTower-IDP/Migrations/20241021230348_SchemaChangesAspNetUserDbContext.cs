using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizTower.IDP.Migrations
{
    /// <inheritdoc />
    public partial class SchemaChangesAspNetUserDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("43613a6e-f767-4ca2-994f-b953dcbf5006"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("47b1d199-e57b-4cbe-b1e2-8d824e043c4d"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("72eb129c-d954-4211-8b94-e3d594705499"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("7a59a12a-aaed-4799-862a-fddd4fb4f521"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("913474cd-d936-4f9d-8431-2aaca8a95dff"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9b8b95bd-2353-4acf-9d9a-3d0f62adde2f"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a489adef-e696-4ea8-afe9-0f60a6a2b70c"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a536485b-56ad-41b4-aaa5-1310d2e9b59d"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ab35d664-e2be-4e2e-8c0b-6a79845c0126"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b25df510-2891-4895-94ba-019995de222c"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("bd7a3177-49f5-464f-b399-b1958e85463d"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e7e73b50-a546-4dd7-98a6-f04aeae04c3a"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f6f9a848-6ae4-483e-b4c5-d3c56c5d5bf8"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fb79ff32-d67c-4424-b358-dabc38a46922"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fd50dee5-cddd-4d6c-b3b4-533eb2c4ceb9"));

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                schema: "Identity",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "Identity",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                schema: "Identity",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "Identity",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                schema: "Identity",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                schema: "Identity",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("22e197f2-558d-4285-a82f-af36d174667c"), "d6cc9df8-1138-4746-b365-1bf53fdb5708", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("28b2ac28-e84e-47df-b9f6-0337c1d1ce65"), "fe2ec61d-fc5f-44ca-a715-108c7d8240d3", "role", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Owner" },
                    { new Guid("38c4d9ea-2752-4a0b-abe1-0bb3792f4f0b"), "0d5c9be8-1b18-43c7-8f40-319a16f4d6dc", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("56d7e111-d635-4dc3-af91-086e2b48d6a9"), "4cf12f5a-1a92-4a32-b503-26a90966d668", "country", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "nl" },
                    { new Guid("60d18746-a82c-4fe6-b4ce-8b53ea83b5a0"), "841935df-9f80-4698-8778-438cb335740c", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("7379c45e-527e-4261-a319-de2abfe0d1e0"), "075a9638-5d39-4fb7-877b-6d4fa564de15", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Player" },
                    { new Guid("758abecd-ff2c-437b-960b-0ee50c04e63b"), "728f738f-2947-4b07-98b8-e6d72c6b4778", "role", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "SecurityAdmin" },
                    { new Guid("8d204b0f-10de-49c6-bdf7-9717c67c0867"), "b4b3febd-0223-4563-b0ad-f3495cc1633b", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("8f581618-9121-4f01-a7f7-47baa9ed370c"), "f568e20a-aae4-475c-8b79-08439d3a63ac", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("94a04b02-afc2-4a59-a6e1-25558bc80ffe"), "d795d5ea-c8c5-42cc-bf39-6a50af5dcb1d", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("b87a91d8-a05c-4aee-98e9-c0d72bfe80e1"), "33476c74-69a3-4e0f-be6f-4e186417d39c", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("c0f363f3-96d7-44d6-89df-fe8341c9debd"), "661784e2-7a5c-4b00-b93d-0b8563a7fc0d", "family_name", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Flagg" },
                    { new Guid("e7b19aa0-b210-45b1-a505-e2d4a8f7b1fd"), "3862d894-303e-44fb-9c03-249e4721d8ce", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("f758e815-d385-42bc-ac61-f48beb0fc8cf"), "78613f40-31b0-4d62-87a7-49530e4fd4f9", "given_name", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Admin" },
                    { new Guid("fc1dd9dc-6d59-465e-bb73-8c628a113191"), "a6eb1744-03db-406e-a574-8232fc62026f", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "QuizMaster" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled" },
                values: new object[] { 0, "39c674aa-13d6-4bb4-a9b5-31eaafa722b1", false, false, null, null, null, "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==", null, false, null, false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled" },
                values: new object[] { 0, "5a5a89fa-8249-4b91-820a-f4fa5a7e6c46", false, false, null, null, null, "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==", null, false, null, false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled" },
                values: new object[] { 0, "7815541c-f3e7-4e36-a4d6-b7d0ed46c677", false, false, null, null, null, "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==", null, false, null, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("22e197f2-558d-4285-a82f-af36d174667c"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("28b2ac28-e84e-47df-b9f6-0337c1d1ce65"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("38c4d9ea-2752-4a0b-abe1-0bb3792f4f0b"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("56d7e111-d635-4dc3-af91-086e2b48d6a9"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("60d18746-a82c-4fe6-b4ce-8b53ea83b5a0"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("7379c45e-527e-4261-a319-de2abfe0d1e0"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("758abecd-ff2c-437b-960b-0ee50c04e63b"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("8d204b0f-10de-49c6-bdf7-9717c67c0867"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("8f581618-9121-4f01-a7f7-47baa9ed370c"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("94a04b02-afc2-4a59-a6e1-25558bc80ffe"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b87a91d8-a05c-4aee-98e9-c0d72bfe80e1"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c0f363f3-96d7-44d6-89df-fe8341c9debd"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e7b19aa0-b210-45b1-a505-e2d4a8f7b1fd"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f758e815-d385-42bc-ac61-f48beb0fc8cf"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fc1dd9dc-6d59-465e-bb73-8c628a113191"));

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

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

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                columns: new[] { "ConcurrencyStamp", "Password" },
                values: new object[] { "71c8d265-9eac-4fcf-be1f-c6b7ecd655ac", "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "ConcurrencyStamp", "Password" },
                values: new object[] { "8315eadb-caa7-452d-8c46-bd15d1791c7b", "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"),
                columns: new[] { "ConcurrencyStamp", "Password" },
                values: new object[] { "2149b3ed-d54d-47a7-afb1-8cde7e7a075a", "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==" });
        }
    }
}
