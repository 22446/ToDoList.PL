using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_objects_ObjectiDd",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_ObjectiDd",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "ObjectiDd",
                table: "tasks");

            migrationBuilder.AddColumn<string>(
                name: "imageName",
                table: "tasks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageName",
                table: "tasks");

            migrationBuilder.AddColumn<int>(
                name: "ObjectiDd",
                table: "tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_ObjectiDd",
                table: "tasks",
                column: "ObjectiDd");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_objects_ObjectiDd",
                table: "tasks",
                column: "ObjectiDd",
                principalTable: "objects",
                principalColumn: "iDd",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
