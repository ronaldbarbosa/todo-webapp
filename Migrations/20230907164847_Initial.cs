using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(15)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", nullable: false),
                    Password = table.Column<string>(type: "varchar(256)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(20)", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoTask_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoTaskList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(20)", nullable: false),
                    Color = table.Column<string>(type: "varchar(7)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTaskList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoTaskList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoTaskTag",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    TodoTasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTaskTag", x => new { x.TagsId, x.TodoTasksId });
                    table.ForeignKey(
                        name: "FK_TodoTaskTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoTaskTag_TodoTask_TodoTasksId",
                        column: x => x.TodoTasksId,
                        principalTable: "TodoTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TodoTaskTodoTaskList_TodoTask_TodoTasksId",
                        column: x => x.TodoTasksId,
                        principalTable: "TodoTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoTask_UserId",
                table: "TodoTask",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoTaskList_UserId",
                table: "TodoTaskList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoTaskTag_TodoTasksId",
                table: "TodoTaskTag",
                column: "TodoTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoTaskTodoTaskList_TodoTasksId",
                table: "TodoTaskTodoTaskList",
                column: "TodoTasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoTaskTag");

            migrationBuilder.DropTable(
                name: "TodoTaskTodoTaskList");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "TodoTaskList");

            migrationBuilder.DropTable(
                name: "TodoTask");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
