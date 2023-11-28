using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ObjectMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObjectFK",
                table: "tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ObjectiDd",
                table: "tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "objects",
                columns: table => new
                {
                    iDd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objects", x => x.iDd);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_ObjectFK",
                table: "tasks",
                column: "ObjectFK");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_ObjectiDd",
                table: "tasks",
                column: "ObjectiDd");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_objects_ObjectFK",
                table: "tasks",
                column: "ObjectFK",
                principalTable: "objects",
                principalColumn: "iDd",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_objects_ObjectiDd",
                table: "tasks",
                column: "ObjectiDd",
                principalTable: "objects",
                principalColumn: "iDd",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_objects_ObjectFK",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_objects_ObjectiDd",
                table: "tasks");

            migrationBuilder.DropTable(
                name: "objects");

            migrationBuilder.DropIndex(
                name: "IX_tasks_ObjectFK",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_ObjectiDd",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "ObjectFK",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "ObjectiDd",
                table: "tasks");
        }
    }
}
