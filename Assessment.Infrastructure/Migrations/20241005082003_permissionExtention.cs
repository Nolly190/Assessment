using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assessment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class permissionExtention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { (short)8, false, "GetReservation" },
                    { (short)9, false, "GetAllReservations" },
                    { (short)10, false, "GetAllReservationNotifications" },
                    { (short)11, false, "GetAllUsers" },
                    { (short)12, false, "GetSingleUser" },
                    { (short)13, false, "BlockUser" },
                    { (short)14, false, "CreateRole" },
                    { (short)15, false, "UsersInRole" },
                    { (short)16, false, "AddUserToRole" },
                    { (short)17, false, "ViewAllPermission" },
                    { (short)18, false, "RemoveUserFromRole" },
                    { (short)19, false, "ViewAllRoles" },
                    { (short)20, false, "RemoveRole" }
                });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(50), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(53), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(53) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(55), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(55) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(57), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(57) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(58), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(59) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(83), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(84) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(85), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(85) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(86), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(87) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(88), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(88) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(61), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(62) });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "IsDeleted", "LastModified", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 11, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(63), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(63), (short)9, (short)1 },
                    { 12, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(64), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(65), (short)10, (short)1 },
                    { 13, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(66), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(66), (short)11, (short)1 },
                    { 14, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(69), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(69), (short)12, (short)1 },
                    { 15, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(70), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(71), (short)13, (short)1 },
                    { 16, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(72), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(72), (short)14, (short)1 },
                    { 17, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(73), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(74), (short)15, (short)1 },
                    { 18, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(75), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(75), (short)16, (short)1 },
                    { 19, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(77), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(77), (short)17, (short)1 },
                    { 20, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(78), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(78), (short)18, (short)1 },
                    { 21, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(80), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(80), (short)19, (short)1 },
                    { 22, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(82), null, false, new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(82), (short)20, (short)1 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(453), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(453) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(456), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(456) });

            migrationBuilder.UpdateData(
                table: "UserInRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(1496), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(1497) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)8);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)9);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)10);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)11);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)12);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)13);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)14);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)15);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)16);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)17);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)18);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)19);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (short)20);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7685), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7685) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7688), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7688) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7690), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7691), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7695), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7699), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7700) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7701), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7701) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7702), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7703) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7705), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7705) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7698), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7698) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(8029), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(8032), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(8032) });

            migrationBuilder.UpdateData(
                table: "UserInRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(8919), new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(8919) });
        }
    }
}
