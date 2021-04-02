using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPrintWebSite.Migrations.StucturDb
{
    public partial class updatingstaus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_statuses_deliveryStatusStatusId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_statuses_orderStatusStatusId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_deliveryStatusStatusId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_orderStatusStatusId",
                table: "orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "orderStatusStatusId",
                table: "orders",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "deliveryStatusStatusId",
                table: "orders",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "orderStatusStatusId",
                table: "orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "deliveryStatusStatusId",
                table: "orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_orders_deliveryStatusStatusId",
                table: "orders",
                column: "deliveryStatusStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_orderStatusStatusId",
                table: "orders",
                column: "orderStatusStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_statuses_deliveryStatusStatusId",
                table: "orders",
                column: "deliveryStatusStatusId",
                principalTable: "statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_statuses_orderStatusStatusId",
                table: "orders",
                column: "orderStatusStatusId",
                principalTable: "statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
