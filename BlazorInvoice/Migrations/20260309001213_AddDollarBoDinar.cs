using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorInvoice.Migrations
{
    /// <inheritdoc />
    public partial class AddDollarBoDinar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DollarBoDinar",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DollarBoDinar",
                table: "Invoices");
        }
    }
}
