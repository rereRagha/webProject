using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPrintWebSite.Migrations.StucturDb
{
    public partial class updatingLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_serviceDetails_items_itemId",
                table: "serviceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_serviceDetails_services_selectedServiceserviceId",
                table: "serviceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_services_serviceDetails_ServiceDetailsId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_services_ServiceDetailsId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_serviceDetails_itemId",
                table: "serviceDetails");

            migrationBuilder.DropIndex(
                name: "IX_serviceDetails_selectedServiceserviceId",
                table: "serviceDetails");

            migrationBuilder.DropColumn(
                name: "ServiceDetailsId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "selectedServiceserviceId",
                table: "serviceDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "itemId",
                table: "serviceDetails",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "selectedServiceId",
                table: "serviceDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "selectedServiceId",
                table: "serviceDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceDetailsId",
                table: "services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "itemId",
                table: "serviceDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "selectedServiceserviceId",
                table: "serviceDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_services_ServiceDetailsId",
                table: "services",
                column: "ServiceDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceDetails_itemId",
                table: "serviceDetails",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceDetails_selectedServiceserviceId",
                table: "serviceDetails",
                column: "selectedServiceserviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_serviceDetails_items_itemId",
                table: "serviceDetails",
                column: "itemId",
                principalTable: "items",
                principalColumn: "itemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_serviceDetails_services_selectedServiceserviceId",
                table: "serviceDetails",
                column: "selectedServiceserviceId",
                principalTable: "services",
                principalColumn: "serviceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_services_serviceDetails_ServiceDetailsId",
                table: "services",
                column: "ServiceDetailsId",
                principalTable: "serviceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
