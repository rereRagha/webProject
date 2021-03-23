using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPrintWebSite.Migrations.StucturDb
{
    public partial class commercilnumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "commrecialNumber",
                table: "printingShops",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "commrecialNumber",
                table: "printingShops");
        }
    }
}
