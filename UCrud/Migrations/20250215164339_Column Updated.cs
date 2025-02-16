using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCrud.Migrations
{
    /// <inheritdoc />
    public partial class ColumnUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFile",
                table: "Students",
                newName: "ImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Students",
                newName: "ImageFile");
        }
    }
}
