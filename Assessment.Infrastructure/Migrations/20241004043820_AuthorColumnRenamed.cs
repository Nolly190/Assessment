using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AuthorColumnRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Authur",
                table: "Books",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Authur",
                table: "Books",
                newName: "IX_Books_Author");

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

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "IsDeleted", "LastModified", "PermissionId", "RoleId" },
                values: new object[] { 10, new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7698), null, false, new DateTime(2024, 10, 4, 4, 38, 19, 814, DateTimeKind.Utc).AddTicks(7698), (short)6, (short)1 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Books",
                newName: "Authur");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Author",
                table: "Books",
                newName: "IX_Books_Authur");

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3725), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3726) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3729), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3729) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3731), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3731) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3732), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3733) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3734), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3734) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3737), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3737) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3738), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3738) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3740), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3741), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(3742) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(4158), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(4162), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "UserInRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(5146), new DateTime(2024, 10, 4, 3, 54, 17, 115, DateTimeKind.Utc).AddTicks(5147) });
        }
    }
}
