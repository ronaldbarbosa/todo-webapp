using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoList.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TodoTaskListId",
                table: "TodoTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Study" },
                    { 2, "Work" }
                });

            migrationBuilder.InsertData(
                table: "TodoTask",
                columns: new[] { "Id", "CreatedDate", "Description", "DueDate", "Finished", "Title", "TodoTaskListId", "UpdatedDate", "UserId" },
                values: new object[] { 1, new DateTime(2023, 9, 9, 21, 44, 18, 648, DateTimeKind.Local).AddTicks(7721), "Study AspNet Core MVC all weekend", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Study", null, new DateTime(2023, 9, 9, 21, 44, 18, 648, DateTimeKind.Local).AddTicks(7732), "50d0af67-12f6-4c63-90e0-7981b9538893" });

            migrationBuilder.InsertData(
                table: "TodoTaskList",
                columns: new[] { "Id", "Color", "Title", "UserId" },
                values: new object[] { 1, "#303032", "Teste", "50d0af67-12f6-4c63-90e0-7981b9538893" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoTask",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoTaskList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "TodoTaskListId",
                table: "TodoTask",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
