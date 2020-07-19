using Microsoft.EntityFrameworkCore.Migrations;

namespace ProWebbCore.Api.Migrations
{
    public partial class AddEmployerFieldtoJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Employer",
                table: "Jobs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ResumeId",
                table: "Jobs",
                column: "ResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Resumes_ResumeId",
                table: "Jobs",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Resumes_ResumeId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ResumeId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Employer",
                table: "Jobs");
        }
    }
}
