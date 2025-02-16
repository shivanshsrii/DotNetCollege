using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCrud.Migrations
{
    /// <inheritdoc />
    public partial class AddedDashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Semester1",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Semester2",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Semester3",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Semester4",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Semester5",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Semester6",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Semester7",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Semester8",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semester1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Semester2",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Semester3",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Semester4",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Semester5",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Semester6",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Semester7",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Semester8",
                table: "Students");
        }
    }
}
