using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedReservationPermissionToAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9719), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9719) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9721), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9722) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9723), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9723) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9725), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9725) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9726), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9726) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9757), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9757) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9759), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9759) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9760), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9760) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9761), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9762) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9729), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9732), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9732) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9740), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9740) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9742), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9742) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9743), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9744) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9745), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9745) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9746), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9746) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9748), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9748) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9749), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9750), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9752), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9752) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9754), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9755) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9756), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9756) });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "IsDeleted", "LastModified", "PermissionId", "RoleId" },
                values: new object[] { 23, new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9730), null, false, new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9730), (short)8, (short)1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 388, DateTimeKind.Utc).AddTicks(75), new DateTime(2024, 10, 5, 8, 23, 13, 388, DateTimeKind.Utc).AddTicks(76) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 388, DateTimeKind.Utc).AddTicks(78), new DateTime(2024, 10, 5, 8, 23, 13, 388, DateTimeKind.Utc).AddTicks(78) });

            migrationBuilder.UpdateData(
                table: "UserInRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 388, DateTimeKind.Utc).AddTicks(988), new DateTime(2024, 10, 5, 8, 23, 13, 388, DateTimeKind.Utc).AddTicks(989) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 23);

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

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(63), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(63) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(64), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(65) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(66), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(66) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(69), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(69) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(70), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(71) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(72), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(72) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(73), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(74) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(75), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(75) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(77), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(77) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(78), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(78) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(80), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(80) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(82), new DateTime(2024, 10, 5, 8, 20, 3, 309, DateTimeKind.Utc).AddTicks(82) });

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
    }
}
