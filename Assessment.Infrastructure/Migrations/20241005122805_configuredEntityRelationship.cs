using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class configuredEntityRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7450), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7453), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7453) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7455), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7455) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7457), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7457) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7459), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7459) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7487), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7487) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7488), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7489) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7490), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7490) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7492), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7492) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7462), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7462) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7465), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7466) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7467), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7467) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7470), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7471), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7472) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7473), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7473) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7475), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7476), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7478), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7478) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7480), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7481), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7482) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7484), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7484) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7485), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7486) });

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7464), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7464) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7958), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7958) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7961), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(7961) });

            migrationBuilder.UpdateData(
                table: "UserInRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(9060), new DateTime(2024, 10, 5, 12, 28, 5, 373, DateTimeKind.Utc).AddTicks(9061) });

            migrationBuilder.CreateIndex(
                name: "IX_BookReservationNotifications_BookId",
                table: "BookReservationNotifications",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReservationNotifications_CustomerId",
                table: "BookReservationNotifications",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookReservationNotifications_Books_BookId",
                table: "BookReservationNotifications",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReservationNotifications_Users_CustomerId",
                table: "BookReservationNotifications",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReservations_Books_BookId",
                table: "BookReservations",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReservations_Users_CustomerId",
                table: "BookReservations",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReservationNotifications_Books_BookId",
                table: "BookReservationNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReservationNotifications_Users_CustomerId",
                table: "BookReservationNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReservations_Books_BookId",
                table: "BookReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReservations_Users_CustomerId",
                table: "BookReservations");

            migrationBuilder.DropIndex(
                name: "IX_BookReservationNotifications_BookId",
                table: "BookReservationNotifications");

            migrationBuilder.DropIndex(
                name: "IX_BookReservationNotifications_CustomerId",
                table: "BookReservationNotifications");

            migrationBuilder.DropColumn(
                name: "IsBanned",
                table: "Users");

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

            migrationBuilder.UpdateData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9730), new DateTime(2024, 10, 5, 8, 23, 13, 387, DateTimeKind.Utc).AddTicks(9730) });

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
    }
}
