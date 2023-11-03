using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECA.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserAddressOwnsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_PostalCode",
                table: "Users",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Users",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Address_Address",
                table: "Users",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Users",
                newName: "Address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Users",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "Address_Address");
        }
    }
}
