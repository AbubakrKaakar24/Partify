using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Partify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _EmailRemovedAndNoPlateAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "NoPlate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoPlate",
                table: "Customers",
                newName: "Email");
        }
    }
}
