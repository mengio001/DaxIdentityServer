using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizTower.IDP.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateTestUserClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("2d755a26-63f5-4beb-ba49-a37587e7d10b"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("446abc40-0579-44f0-bce6-e181e62ad861"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("73301ad3-1f0d-4ca0-8eca-e5510a74bb43"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("8839bd46-7830-42d1-89e7-571d7dba03a7"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("97e09cf4-42b4-48da-8967-2fe257283dd6"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("a1c8d13f-a4ae-43b0-a1a0-41d5c9543ec6"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("b7fde053-c225-4d11-b54c-5d728439ca10"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("ca0e9695-9a79-43fc-b622-6dc75e1d9bae"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "a08f77cb-e88b-495a-9785-ac74668557af");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "37a4cc63-b172-474c-9593-1efbafd25a28");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserClaim",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("2d755a26-63f5-4beb-ba49-a37587e7d10b"), "b8139a36-2e5d-4423-8e16-92a94a738bf5", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("446abc40-0579-44f0-bce6-e181e62ad861"), "8caa3e22-72c7-44fa-b39d-9a803321be17", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("73301ad3-1f0d-4ca0-8eca-e5510a74bb43"), "dd59cd77-5007-47e0-b233-0826470558aa", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("8839bd46-7830-42d1-89e7-571d7dba03a7"), "8990169f-52ec-44ef-a3bc-8ffe0b57055c", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("97e09cf4-42b4-48da-8967-2fe257283dd6"), "1d3436de-75f5-46fd-8cbd-5c630b2865ae", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("a1c8d13f-a4ae-43b0-a1a0-41d5c9543ec6"), "0c806b12-0d83-4de5-927f-b3bafcb193bd", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("b7fde053-c225-4d11-b54c-5d728439ca10"), "12d2b5ff-8d90-4cd1-8bcd-f74f6a99b38d", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("ca0e9695-9a79-43fc-b622-6dc75e1d9bae"), "cc797d43-ed87-4ef6-bbb0-e69753a20a35", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" }
                });
        }
    }
}
