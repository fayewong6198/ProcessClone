using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessClone.Server.Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ComponentId = table.Column<int>(type: "INTEGER", nullable: false),
                    GrandMasterId = table.Column<string>(type: "TEXT", nullable: true),
                    MasterId = table.Column<string>(type: "TEXT", nullable: true),
                    AssigneeId = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoTask_AspNetUsers_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDoTask_AspNetUsers_GrandMasterId",
                        column: x => x.GrandMasterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDoTask_AspNetUsers_MasterId",
                        column: x => x.MasterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDoTask_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTask_AssigneeId",
                table: "ToDoTask",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTask_ComponentId",
                table: "ToDoTask",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTask_GrandMasterId",
                table: "ToDoTask",
                column: "GrandMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTask_MasterId",
                table: "ToDoTask",
                column: "MasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoTask");

            migrationBuilder.DropTable(
                name: "Component");
        }
    }
}
