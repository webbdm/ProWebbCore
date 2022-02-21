using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProWebbCore.Api.Migrations
{
    public partial class create_goal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoteName",
                table: "KeyNote",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyNote_KeyID",
                table: "KeyNote",
                column: "KeyID");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyNote_Key_KeyID",
                table: "KeyNote",
                column: "KeyID",
                principalTable: "Key",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyNote_Key_KeyID",
                table: "KeyNote");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropIndex(
                name: "IX_KeyNote_KeyID",
                table: "KeyNote");

            migrationBuilder.DropColumn(
                name: "NoteName",
                table: "KeyNote");
        }
    }
}
