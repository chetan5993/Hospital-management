using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    public partial class AfterFirstTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Timings_DoctorId",
                table: "Timings");

            migrationBuilder.CreateIndex(
                name: "IX_Timings_DoctorId",
                table: "Timings",
                column: "DoctorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Timings_DoctorId",
                table: "Timings");

            migrationBuilder.CreateIndex(
                name: "IX_Timings_DoctorId",
                table: "Timings",
                column: "DoctorId");
        }
    }
}
