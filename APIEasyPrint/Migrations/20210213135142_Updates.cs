using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPrintWebSite.Migrations.StucturDb
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_documents_customers_CustomerId",
                table: "documents");

            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_customers_CustomerId",
                table: "feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_deliveryDrivers_DeliveryDriverinvoiceId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_privatePromotionCodes_customers_CustomerId",
                table: "privatePromotionCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_problemReports_admins_adminId",
                table: "problemReports");

            migrationBuilder.DropForeignKey(
                name: "FK_services_serviceDetails_ServiceDetailsinvoiceId",
                table: "services");

            migrationBuilder.DropForeignKey(
                name: "FK_suggestions_customers_CustomerId",
                table: "suggestions");

            migrationBuilder.DropForeignKey(
                name: "FK_suggestions_admins_adminId",
                table: "suggestions");

            migrationBuilder.DropIndex(
                name: "IX_services_ServiceDetailsinvoiceId",
                table: "services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_serviceDetails",
                table: "serviceDetails");

            migrationBuilder.DropIndex(
                name: "IX_orders_DeliveryDriverinvoiceId",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deliveryDrivers",
                table: "deliveryDrivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deliverOptions",
                table: "deliverOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_admins",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "ServiceDetailsinvoiceId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "invoiceId",
                table: "serviceDetails");

            migrationBuilder.DropColumn(
                name: "DeliveryDriverinvoiceId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "invoiceId",
                table: "deliveryDrivers");

            migrationBuilder.DropColumn(
                name: "invoiceId",
                table: "deliverOptions");

            migrationBuilder.DropColumn(
                name: "invoiceId",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "invoiceId",
                table: "admins");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceDetailsId",
                table: "services",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "serviceDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryDriverId",
                table: "orders",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "deliveryDrivers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "deliverOptions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "admins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_serviceDetails",
                table: "serviceDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deliveryDrivers",
                table: "deliveryDrivers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deliverOptions",
                table: "deliverOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admins",
                table: "admins",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_services_ServiceDetailsId",
                table: "services",
                column: "ServiceDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_DeliveryDriverId",
                table: "orders",
                column: "DeliveryDriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_documents_customers_CustomerId",
                table: "documents",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_customers_CustomerId",
                table: "feedbacks",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_deliveryDrivers_DeliveryDriverId",
                table: "orders",
                column: "DeliveryDriverId",
                principalTable: "deliveryDrivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_privatePromotionCodes_customers_CustomerId",
                table: "privatePromotionCodes",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_problemReports_admins_adminId",
                table: "problemReports",
                column: "adminId",
                principalTable: "admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_services_serviceDetails_ServiceDetailsId",
                table: "services",
                column: "ServiceDetailsId",
                principalTable: "serviceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_suggestions_customers_CustomerId",
                table: "suggestions",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_suggestions_admins_adminId",
                table: "suggestions",
                column: "adminId",
                principalTable: "admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_documents_customers_CustomerId",
                table: "documents");

            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_customers_CustomerId",
                table: "feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_deliveryDrivers_DeliveryDriverId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_privatePromotionCodes_customers_CustomerId",
                table: "privatePromotionCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_problemReports_admins_adminId",
                table: "problemReports");

            migrationBuilder.DropForeignKey(
                name: "FK_services_serviceDetails_ServiceDetailsId",
                table: "services");

            migrationBuilder.DropForeignKey(
                name: "FK_suggestions_customers_CustomerId",
                table: "suggestions");

            migrationBuilder.DropForeignKey(
                name: "FK_suggestions_admins_adminId",
                table: "suggestions");

            migrationBuilder.DropIndex(
                name: "IX_services_ServiceDetailsId",
                table: "services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_serviceDetails",
                table: "serviceDetails");

            migrationBuilder.DropIndex(
                name: "IX_orders_DeliveryDriverId",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deliveryDrivers",
                table: "deliveryDrivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deliverOptions",
                table: "deliverOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_admins",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "ServiceDetailsId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "serviceDetails");

            migrationBuilder.DropColumn(
                name: "DeliveryDriverId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "deliverOptions");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceDetailsinvoiceId",
                table: "services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "invoiceId",
                table: "serviceDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryDriverinvoiceId",
                table: "orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "deliveryDrivers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "invoiceId",
                table: "deliveryDrivers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "invoiceId",
                table: "deliverOptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "invoiceId",
                table: "customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "admins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "invoiceId",
                table: "admins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_serviceDetails",
                table: "serviceDetails",
                column: "invoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deliveryDrivers",
                table: "deliveryDrivers",
                column: "invoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deliverOptions",
                table: "deliverOptions",
                column: "invoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "invoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admins",
                table: "admins",
                column: "invoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_services_ServiceDetailsinvoiceId",
                table: "services",
                column: "ServiceDetailsinvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_DeliveryDriverinvoiceId",
                table: "orders",
                column: "DeliveryDriverinvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_documents_customers_CustomerId",
                table: "documents",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "invoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_customers_CustomerId",
                table: "feedbacks",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "invoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "invoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_deliveryDrivers_DeliveryDriverinvoiceId",
                table: "orders",
                column: "DeliveryDriverinvoiceId",
                principalTable: "deliveryDrivers",
                principalColumn: "invoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_privatePromotionCodes_customers_CustomerId",
                table: "privatePromotionCodes",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "invoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_problemReports_admins_adminId",
                table: "problemReports",
                column: "adminId",
                principalTable: "admins",
                principalColumn: "invoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_services_serviceDetails_ServiceDetailsinvoiceId",
                table: "services",
                column: "ServiceDetailsinvoiceId",
                principalTable: "serviceDetails",
                principalColumn: "invoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_suggestions_customers_CustomerId",
                table: "suggestions",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "invoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_suggestions_admins_adminId",
                table: "suggestions",
                column: "adminId",
                principalTable: "admins",
                principalColumn: "invoiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
