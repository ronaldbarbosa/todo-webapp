using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_User_UserId",
                table: "TodoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTaskList_User_UserId",
                table: "TodoTaskList");

            migrationBuilder.DropTable(
                name: "TodoTaskTodoTaskList");

            migrationBuilder.AddColumn<int>(
                name: "TodoTaskListId",
                table: "TodoTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TodoTask_TodoTaskListId",
                table: "TodoTask",
                column: "TodoTaskListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_TodoTaskList_TodoTaskListId",
                table: "TodoTask",
                column: "TodoTaskListId",
                principalTable: "TodoTaskList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_User_UserId",
                table: "TodoTask",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTaskList_User_UserId",
                table: "TodoTaskList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_TodoTaskList_TodoTaskListId",
                table: "TodoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_User_UserId",
                table: "TodoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTaskList_User_UserId",
                table: "TodoTaskList");

            migrationBuilder.DropIndex(
                name: "IX_TodoTask_TodoTaskListId",
                table: "TodoTask");

            migrationBuilder.DropColumn(
                name: "TodoTaskListId",
                table: "TodoTask");

            migrationBuilder.CreateTable(
                name: "TodoTaskTodoTaskList",
                columns: table => new
                {
                    TodoTaskListId = table.Column<int>(type: "int", nullable: false),
                    TodoTasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTaskTodoTaskList", x => new { x.TodoTaskListId, x.TodoTasksId });
                    table.ForeignKey(
                        name: "FK_TodoTaskTodoTaskList_TodoTaskList_TodoTaskListId",
                        column: x => x.TodoTaskListId,
                        principalTable: "TodoTaskList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoTaskTodoTaskList_TodoTask_TodoTasksId",
                        column: x => x.TodoTasksId,
                        principalTable: "TodoTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoTaskTodoTaskList_TodoTasksId",
                table: "TodoTaskTodoTaskList",
                column: "TodoTasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_User_UserId",
                table: "TodoTask",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTaskList_User_UserId",
                table: "TodoTaskList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
