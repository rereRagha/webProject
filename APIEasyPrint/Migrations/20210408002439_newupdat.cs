using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPrintWebSite.Migrations.StucturDb
{
    public partial class newupdat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "prenterName",
                table: "applicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "prentingShopId",
                table: "applicationUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prenterName",
                table: "applicationUsers");

            migrationBuilder.DropColumn(
                name: "prentingShopId",
                table: "applicationUsers");
        }
    }
}
