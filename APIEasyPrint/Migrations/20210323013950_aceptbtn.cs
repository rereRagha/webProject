using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPrintWebSite.Migrations.StucturDb
{
    public partial class aceptbtn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAccepted",
                table: "printingShops",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAccepted",
                table: "printingShops");
        }
    }
}
