using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assessment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { (short)1, false, "AddBook" },
                    { (short)2, false, "GetBook" },
                    { (short)3, false, "SearchBook" },
                    { (short)4, false, "BookReturn" },
                    { (short)5, false, "ReservationNotification" },
                    { (short)6, false, "BookCollection" },
                    { (short)7, false, "ReserveBook" }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "IsDeleted", "LastModified", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3725), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3726), (short)1, (short)1 },
                    { 2, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3729), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3729), (short)2, (short)1 },
                    { 3, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3731), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3731), (short)3, (short)1 },
                    { 4, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3732), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3733), (short)4, (short)1 },
                    { 5, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3734), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3734), (short)5, (short)1 },
                    { 6, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3737), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3737), (short)2, (short)2 },
                    { 7, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3738), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3738), (short)3, (short)2 },
                    { 8, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3740), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3740), (short)7, (short)2 },
                    { 9, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3741), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3742), (short)5, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "IsDeleted", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(4158), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(4159), "Admin" },
                    { 2, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(4162), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(4162), "User" }
                });

            migrationBuilder.InsertData(
                table: "UserInRoles",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "IsDeleted", "LastModified", "RoleId", "UserId" },
                values: new object[] { 1, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(5146), null, false, new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(5147), (short)1, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)7);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserInRoles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
