using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreIdentity.App.Web.Migrations
{
    /// <inheritdoc />
    public partial class NewBrithDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrityDay",
                table: "AspNetUsers",
                newName: "BrityDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrityDate",
                table: "AspNetUsers",
                newName: "BrityDay");
        }
    }
}
