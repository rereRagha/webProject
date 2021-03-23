using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPrintWebSite.Migrations.StucturDb
{
    public partial class updating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "fileBytes",
                table: "documents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fileType",
                table: "documents",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "size",
                table: "documents",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fileBytes",
                table: "documents");

            migrationBuilder.DropColumn(
                name: "fileType",
                table: "documents");

            migrationBuilder.DropColumn(
                name: "size",
                table: "documents");
        }
    }
}
