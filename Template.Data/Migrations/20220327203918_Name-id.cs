using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class Nameid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "UserId",
                table: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b214de7-8958-4956-8eed-28f9ba2c47c6"),
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 3, 27, 17, 39, 16, 594, DateTimeKind.Local).AddTicks(442), new DateTime(2022, 3, 27, 17, 39, 16, 598, DateTimeKind.Local).AddTicks(6482) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "UserId",
                table: "Users",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b214de7-8958-4956-8eed-28f9ba2c47c6"),
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 3, 27, 17, 32, 13, 206, DateTimeKind.Local).AddTicks(5627), new DateTime(2022, 3, 27, 17, 32, 13, 210, DateTimeKind.Local).AddTicks(3793) });
        }
    }
}
