using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizTower.IDP.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class NewUserSecurityAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("321e456e-1086-44ab-9b8e-09eb29f5082a"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("34c41f41-5c75-4c68-9ec2-bbd78dab3791"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("3cb93f07-eb93-489b-96a4-215b0f47ad2f"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("64d4a8ca-367d-486d-abee-603f6b151127"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("66050d9f-d705-4e86-91e7-53b5a8dda1c8"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("745e1caa-b888-45de-9201-d0b354bdeac9"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("7dff22f7-ef0e-46e4-bcfa-226976770668"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("b5f080de-b2bf-47b1-8df4-057d48f8b7f5"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("bb459ef5-f632-4850-bded-af5d59e54fb6"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("f7c639a4-4ca6-4e98-bbd2-3473b9a79397"));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "0834704c-508c-4281-87e5-b1e62dc8ca31");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "be8fee15-d7bd-478d-b935-6a929cc10524");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "UserName" },
                values: new object[] { new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), true, "c0bae308-fa8a-4bf4-8cb3-1d4d6e021a0e", "admin@admin.com", "AQAAAAIAAYagAAAAEAFfhxfb2YqaRx4WePWJMkIE/tmk/oY7csVwmRqu63+TjAVYgulpGORreroxJD1AdA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B8C91EF2-7C41-4561-A323-A73B8F25F686", "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserClaim",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("0f6386d9-f13a-4f00-9425-18db3529d845"), "50c1dfb3-8b15-46cf-9aa4-48fdf28926c0", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "QuizMaster" },
                    { new Guid("1fa942cd-7b3d-46e2-a618-9999501e1430"), "6996f153-944f-4b9d-9683-1800824f4422", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("38d82d94-cd22-458d-ab07-dd991e57992a"), "e056937f-0ddc-4d7b-8b6e-dadbb983f7d7", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("500824a9-cfc3-44f4-95a6-00dda3119776"), "b1f0b545-1cb2-462f-be4b-7de6d9c96769", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Player" },
                    { new Guid("62a48c70-ce2a-42c4-912a-c6a3af76c17f"), "c098f3d5-a5e0-484b-99d3-cb09c580e746", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("70d7c9b2-7075-431c-b60a-26e0a877088f"), "7a67c70e-f125-4929-b6ae-9756808174f3", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("75c8aea7-3fcb-490d-9abc-a64d550744b9"), "30d19694-3d63-4eac-81a1-f04e9288c83c", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("bde0fecd-3a51-458f-9a41-d04e183fa789"), "7359c90f-081f-49c7-8dab-cfd59adbaa58", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("e3b7f13a-6c42-40bd-8271-04028c3c2391"), "c214c0f7-b235-4e2f-8b0c-c940970498d3", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("ea418934-1932-4365-b02d-0a9c35142121"), "983ee73f-f6f3-4849-a2a4-f48bd7139187", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("70439a71-cf9a-45c0-9285-0d16f43c9d1e"), "c9a1e7b8-6a13-4ff4-a38a-0eb2cee2f602", "country", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "nl" },
                    { new Guid("7508f74b-cea5-4f7e-b979-6e6b5c0ea386"), "348d3689-361f-4269-903e-510c718ef353", "role", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "SecurityAdmin" },
                    { new Guid("a64dd79f-e5b0-4d90-b744-f948053bfba5"), "309bfa08-5101-4a46-bce0-829c454c9b12", "family_name", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Flagg" },
                    { new Guid("c5ed8aa3-c2c2-4043-b0b2-8f3c56382843"), "4a14e36f-9732-4e04-893c-39c71177bc46", "role", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Owner" },
                    { new Guid("e484ea34-47fe-43ef-927e-def80e78c604"), "9de24964-7ce9-47f1-a6e2-f801c7ec1654", "given_name", new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"), "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("0f6386d9-f13a-4f00-9425-18db3529d845"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("1fa942cd-7b3d-46e2-a618-9999501e1430"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("38d82d94-cd22-458d-ab07-dd991e57992a"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("500824a9-cfc3-44f4-95a6-00dda3119776"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("62a48c70-ce2a-42c4-912a-c6a3af76c17f"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("70439a71-cf9a-45c0-9285-0d16f43c9d1e"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("70d7c9b2-7075-431c-b60a-26e0a877088f"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("7508f74b-cea5-4f7e-b979-6e6b5c0ea386"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("75c8aea7-3fcb-490d-9abc-a64d550744b9"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("a64dd79f-e5b0-4d90-b744-f948053bfba5"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("bde0fecd-3a51-458f-9a41-d04e183fa789"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("c5ed8aa3-c2c2-4043-b0b2-8f3c56382843"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("e3b7f13a-6c42-40bd-8271-04028c3c2391"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("e484ea34-47fe-43ef-927e-def80e78c604"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("ea418934-1932-4365-b02d-0a9c35142121"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a120fd96-1dea-4922-8403-289e5f2dbb6a"));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "79d578fd-43e8-4ee9-b640-b7ddddf7e4d8");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "8548990b-1758-4659-873d-55b3fb517e21");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserClaim",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("321e456e-1086-44ab-9b8e-09eb29f5082a"), "c6ce6710-34ba-4a09-994d-17a16734263e", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("34c41f41-5c75-4c68-9ec2-bbd78dab3791"), "a00d0d41-8f9d-4acd-85cf-1b58689edfb5", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("3cb93f07-eb93-489b-96a4-215b0f47ad2f"), "771306e6-40c6-4829-9a28-8f8f4def3498", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("64d4a8ca-367d-486d-abee-603f6b151127"), "04c89e70-6c33-4a53-af96-55c7bd8f897e", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("66050d9f-d705-4e86-91e7-53b5a8dda1c8"), "2cdd2176-7965-4ae3-90b2-4134fe8b1f5f", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("745e1caa-b888-45de-9201-d0b354bdeac9"), "a3d7260a-872b-4e21-8ebc-2b54de7dec6a", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Player" },
                    { new Guid("7dff22f7-ef0e-46e4-bcfa-226976770668"), "04654374-60d6-429b-82d8-963f42d38aa3", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("b5f080de-b2bf-47b1-8df4-057d48f8b7f5"), "466016a1-1cb9-4505-9f76-5b8501707a51", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "QuizMaster" },
                    { new Guid("bb459ef5-f632-4850-bded-af5d59e54fb6"), "c5c58278-2395-48c2-b4c1-4374f8218a80", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("f7c639a4-4ca6-4e98-bbd2-3473b9a79397"), "376d5c37-49b8-4b14-b652-14aab4018fee", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" }
                });
        }
    }
}
