using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Goldan_Maria_EB_lab2.Migrations
{
    /// <inheritdoc />
    public partial class CustomerChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customer",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Customer",
                newName: "CustomerID");
        }
    }
}
