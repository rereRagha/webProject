using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPrintWebSite.Migrations.StucturDb
{
    public partial class newDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_printingShops_addresses_addressinvoiceId",
                table: "printingShops");

            migrationBuilder.DropForeignKey(
                name: "FK_sellUnits_services_serviceId",
                table: "sellUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_services_sellUnits_selectedSellUnitsellUnitId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_services_selectedSellUnitsellUnitId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_sellUnits_serviceId",
                table: "sellUnits");

            migrationBuilder.DropIndex(
                name: "IX_printingShops_addressinvoiceId",
                table: "printingShops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "selectedSellUnitsellUnitId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "serviceId",
                table: "sellUnits");

            migrationBuilder.DropColumn(
                name: "addressinvoiceId",
                table: "printingShops");

            migrationBuilder.DropColumn(
                name: "invoiceId",
                table: "addresses");

            migrationBuilder.AlterColumn<string>(
                name: "serviceDescreption",
                table: "services",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "services",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "SellUnitsellUnitId",
                table: "services",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "printingShopId",
                table: "services",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "addressUserId",
                table: "printingShops",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "addresses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_printingShops_addressUserId",
                table: "printingShops",
                column: "addressUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_printingShops_addresses_addressUserId",
                table: "printingShops",
                column: "addressUserId",
                principalTable: "addresses",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_printingShops_addresses_addressUserId",
                table: "printingShops");

            migrationBuilder.DropIndex(
                name: "IX_printingShops_addressUserId",
                table: "printingShops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "services");

            migrationBuilder.DropColumn(
                name: "SellUnitsellUnitId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "printingShopId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "addressUserId",
                table: "printingShops");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "addresses");

            migrationBuilder.AlterColumn<string>(
                name: "serviceDescreption",
                table: "services",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "selectedSellUnitsellUnitId",
                table: "services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "serviceId",
                table: "sellUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "addressinvoiceId",
                table: "printingShops",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "invoiceId",
                table: "addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "invoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_services_selectedSellUnitsellUnitId",
                table: "services",
                column: "selectedSellUnitsellUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_sellUnits_serviceId",
                table: "sellUnits",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_printingShops_addressinvoiceId",
                table: "printingShops",
                column: "addressinvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_printingShops_addresses_addressinvoiceId",
                table: "printingShops",
                column: "addressinvoiceId",
                principalTable: "addresses",
                principalColumn: "invoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sellUnits_services_serviceId",
                table: "sellUnits",
                column: "serviceId",
                principalTable: "services",
                principalColumn: "serviceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_services_sellUnits_selectedSellUnitsellUnitId",
                table: "services",
                column: "selectedSellUnitsellUnitId",
                principalTable: "sellUnits",
                principalColumn: "sellUnitId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
