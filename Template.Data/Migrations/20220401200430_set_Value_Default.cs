using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class set_Value_Default : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 1, 17, 4, 29, 607, DateTimeKind.Local).AddTicks(1031),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 1, 17, 4, 29, 587, DateTimeKind.Local).AddTicks(9005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b214de7-8958-4956-8eed-28f9ba2c47c6"),
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 4, 1, 17, 4, 29, 578, DateTimeKind.Local).AddTicks(9818), new DateTime(2022, 4, 1, 17, 4, 29, 583, DateTimeKind.Local).AddTicks(2076) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 1, 17, 4, 29, 607, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 1, 17, 4, 29, 587, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b214de7-8958-4956-8eed-28f9ba2c47c6"),
                columns: new[] { "CreationDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 3, 27, 17, 39, 16, 594, DateTimeKind.Local).AddTicks(442), new DateTime(2022, 3, 27, 17, 39, 16, 598, DateTimeKind.Local).AddTicks(6482) });
        }
    }
}
