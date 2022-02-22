using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProWebbCore.Api.Migrations
{
    public partial class create_skills_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Split",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GoalID = table.Column<int>(nullable: false),
                    ProteinSplit = table.Column<double>(nullable: false),
                    FatSplit = table.Column<double>(nullable: false),
                    CarbohydrateSplit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Split", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Split_Goal_GoalID",
                        column: x => x.GoalID,
                        principalTable: "Goal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Split_GoalID",
                table: "Split",
                column: "GoalID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Split");
        }
    }
}
