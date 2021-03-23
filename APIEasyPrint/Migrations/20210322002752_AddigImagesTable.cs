using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPrintWebSite.Migrations.StucturDb
{
    public partial class AddigImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrintingShopEmail",
                table: "printingShops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "printingShops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "commrecialName",
                table: "printingShops",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "orderCreationDate",
                table: "orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "orderEndDate",
                table: "orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "addresses",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "latitudeDelta",
                table: "addresses",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "addresses",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "longitudeDelta",
                table: "addresses",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    ImgId = table.Column<Guid>(nullable: false),
                    ImgeBytes = table.Column<byte[]>(nullable: true),
                    siz = table.Column<double>(nullable: false),
                    ItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.ImgId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropColumn(
                name: "PrintingShopEmail",
                table: "printingShops");

            migrationBuilder.DropColumn(
                name: "city",
                table: "printingShops");

            migrationBuilder.DropColumn(
                name: "commrecialName",
                table: "printingShops");

            migrationBuilder.DropColumn(
                name: "orderCreationDate",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "orderEndDate",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "latitudeDelta",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "longitudeDelta",
                table: "addresses");
        }
    }
}
