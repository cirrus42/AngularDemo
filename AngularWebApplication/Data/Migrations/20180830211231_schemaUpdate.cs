using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularWebApplication.Data.Migrations
{
    public partial class schemaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Users",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CretedDate",
                table: "Users",
                newName: "CreatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "Users",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Users",
                newName: "CretedDate");
        }
    }
}
