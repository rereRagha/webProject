using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPrintWebSite.Migrations.StucturDb
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    invoiceId = table.Column<Guid>(nullable: false),
                    country = table.Column<string>(maxLength: 100, nullable: false),
                    city = table.Column<string>(maxLength: 100, nullable: false),
                    neighborhood = table.Column<string>(maxLength: 200, nullable: false),
                    street = table.Column<string>(maxLength: 100, nullable: false),
                    adressLine = table.Column<string>(maxLength: 200, nullable: true),
                    postcode = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.invoiceId);
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    invoiceId = table.Column<Guid>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.invoiceId);
                });

            migrationBuilder.CreateTable(
                name: "applicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    invoiceId = table.Column<Guid>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.invoiceId);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    StatusId = table.Column<Guid>(nullable: false),
                    statusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    subjectId = table.Column<Guid>(nullable: false),
                    subjectName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.subjectId);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    docId = table.Column<Guid>(nullable: false),
                    docTitle = table.Column<string>(maxLength: 100, nullable: false),
                    docLocation = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.docId);
                    table.ForeignKey(
                        name: "FK_documents_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "suggestions",
                columns: table => new
                {
                    suggestionId = table.Column<Guid>(nullable: false),
                    suggestionTitle = table.Column<string>(maxLength: 100, nullable: false),
                    suggestionDescription = table.Column<string>(maxLength: 500, nullable: false),
                    suggestionDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    adminId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suggestions", x => x.suggestionId);
                    table.ForeignKey(
                        name: "FK_suggestions_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_suggestions_admins_adminId",
                        column: x => x.adminId,
                        principalTable: "admins",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "printingShops",
                columns: table => new
                {
                    prentingShopId = table.Column<Guid>(nullable: false),
                    prenterName = table.Column<string>(maxLength: 200, nullable: false),
                    isCourseMaterial = table.Column<bool>(nullable: false),
                    isService = table.Column<bool>(nullable: false),
                    addressinvoiceId = table.Column<Guid>(nullable: true),
                    ownerId = table.Column<string>(nullable: true),
                    applicationUserId = table.Column<string>(nullable: true),
                    orderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_printingShops", x => x.prentingShopId);
                    table.ForeignKey(
                        name: "FK_printingShops_addresses_addressinvoiceId",
                        column: x => x.addressinvoiceId,
                        principalTable: "addresses",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_printingShops_applicationUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "applicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "courceMaterials",
                columns: table => new
                {
                    courceMaterialId = table.Column<Guid>(nullable: false),
                    courceMaterialTitle = table.Column<string>(maxLength: 100, nullable: false),
                    courceMaterialDescreption = table.Column<string>(maxLength: 300, nullable: false),
                    courceMaterialPrice = table.Column<double>(nullable: false),
                    isAvailable = table.Column<bool>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false),
                    printingShopId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courceMaterials", x => x.courceMaterialId);
                    table.ForeignKey(
                        name: "FK_courceMaterials_subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjects",
                        principalColumn: "subjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courceMaterials_printingShops_printingShopId",
                        column: x => x.printingShopId,
                        principalTable: "printingShops",
                        principalColumn: "prentingShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deliverOptions",
                columns: table => new
                {
                    invoiceId = table.Column<Guid>(nullable: false),
                    isPickUp = table.Column<bool>(nullable: false),
                    pickUpPrice = table.Column<double>(nullable: false),
                    isHomeDelivery = table.Column<bool>(nullable: false),
                    homeDeliveryPrice = table.Column<double>(nullable: false),
                    isMailDelivery = table.Column<bool>(nullable: false),
                    mailDeliveryPrice = table.Column<double>(nullable: false),
                    printingShopId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliverOptions", x => x.invoiceId);
                    table.ForeignKey(
                        name: "FK_deliverOptions_printingShops_printingShopId",
                        column: x => x.printingShopId,
                        principalTable: "printingShops",
                        principalColumn: "prentingShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deliveryDrivers",
                columns: table => new
                {
                    invoiceId = table.Column<Guid>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    printingShopprentingShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryDrivers", x => x.invoiceId);
                    table.ForeignKey(
                        name: "FK_deliveryDrivers_printingShops_printingShopprentingShopId",
                        column: x => x.printingShopprentingShopId,
                        principalTable: "printingShops",
                        principalColumn: "prentingShopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "privatePromotionCodes",
                columns: table => new
                {
                    privatePromotionCodeId = table.Column<Guid>(nullable: false),
                    privatePromotionCodeString = table.Column<string>(maxLength: 50, nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    expireDate = table.Column<DateTime>(nullable: false),
                    isExpired = table.Column<bool>(nullable: false),
                    isUsed = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    printingShopId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_privatePromotionCodes", x => x.privatePromotionCodeId);
                    table.ForeignKey(
                        name: "FK_privatePromotionCodes_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_privatePromotionCodes_printingShops_printingShopId",
                        column: x => x.printingShopId,
                        principalTable: "printingShops",
                        principalColumn: "prentingShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "problemReports",
                columns: table => new
                {
                    problemId = table.Column<Guid>(nullable: false),
                    problemTitle = table.Column<string>(maxLength: 100, nullable: false),
                    problemDescription = table.Column<string>(maxLength: 500, nullable: false),
                    problemDate = table.Column<DateTime>(nullable: false),
                    PrintingShopId = table.Column<Guid>(nullable: false),
                    adminId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_problemReports", x => x.problemId);
                    table.ForeignKey(
                        name: "FK_problemReports_printingShops_PrintingShopId",
                        column: x => x.PrintingShopId,
                        principalTable: "printingShops",
                        principalColumn: "prentingShopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_problemReports_admins_adminId",
                        column: x => x.adminId,
                        principalTable: "admins",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "publicPromotionCodes",
                columns: table => new
                {
                    publicPromotionCodeId = table.Column<Guid>(nullable: false),
                    publicPromotionCodeString = table.Column<string>(maxLength: 50, nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    expireDate = table.Column<DateTime>(nullable: false),
                    isExpired = table.Column<bool>(nullable: false),
                    printingShopId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publicPromotionCodes", x => x.publicPromotionCodeId);
                    table.ForeignKey(
                        name: "FK_publicPromotionCodes_printingShops_printingShopId",
                        column: x => x.printingShopId,
                        principalTable: "printingShops",
                        principalColumn: "prentingShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderId = table.Column<Guid>(nullable: false),
                    total = table.Column<double>(nullable: false),
                    numberOfItems = table.Column<int>(nullable: false),
                    orderStatusStatusId = table.Column<Guid>(nullable: true),
                    deliveryStatusStatusId = table.Column<Guid>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    DeliveryDriverinvoiceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_orders_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_deliveryDrivers_DeliveryDriverinvoiceId",
                        column: x => x.DeliveryDriverinvoiceId,
                        principalTable: "deliveryDrivers",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_statuses_deliveryStatusStatusId",
                        column: x => x.deliveryStatusStatusId,
                        principalTable: "statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_statuses_orderStatusStatusId",
                        column: x => x.orderStatusStatusId,
                        principalTable: "statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "checkoutDetailes",
                columns: table => new
                {
                    invoiceId = table.Column<Guid>(nullable: false),
                    paymentMethod = table.Column<string>(nullable: false),
                    amount = table.Column<double>(nullable: false),
                    deliveryDate = table.Column<DateTime>(nullable: false),
                    paymentDate = table.Column<DateTime>(nullable: false),
                    orderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkoutDetailes", x => x.invoiceId);
                    table.ForeignKey(
                        name: "FK_checkoutDetailes_orders_orderId",
                        column: x => x.orderId,
                        principalTable: "orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    feedBackId = table.Column<Guid>(nullable: false),
                    feedBackRate = table.Column<int>(nullable: false),
                    feedBackDescription = table.Column<string>(maxLength: 500, nullable: true),
                    feedBackDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    orderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.feedBackId);
                    table.ForeignKey(
                        name: "FK_feedbacks_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_feedbacks_orders_orderId",
                        column: x => x.orderId,
                        principalTable: "orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    itemId = table.Column<Guid>(nullable: false),
                    isCourceMaterial = table.Column<bool>(nullable: false),
                    isPrintingOrder = table.Column<bool>(nullable: false),
                    totalPriceOfTheItem = table.Column<double>(nullable: false),
                    courceMaterialId = table.Column<Guid>(nullable: false),
                    docId = table.Column<Guid>(nullable: false),
                    documentdocId = table.Column<Guid>(nullable: true),
                    orderId = table.Column<Guid>(nullable: false),
                    printingShopId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_items_courceMaterials_courceMaterialId",
                        column: x => x.courceMaterialId,
                        principalTable: "courceMaterials",
                        principalColumn: "courceMaterialId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_items_documents_documentdocId",
                        column: x => x.documentdocId,
                        principalTable: "documents",
                        principalColumn: "docId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_items_orders_orderId",
                        column: x => x.orderId,
                        principalTable: "orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_items_printingShops_printingShopId",
                        column: x => x.printingShopId,
                        principalTable: "printingShops",
                        principalColumn: "prentingShopId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "serviceDetails",
                columns: table => new
                {
                    invoiceId = table.Column<Guid>(nullable: false),
                    selectedServiceserviceId = table.Column<Guid>(nullable: true),
                    ServicePrice = table.Column<double>(nullable: false),
                    printingShopId = table.Column<Guid>(nullable: false),
                    itemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceDetails", x => x.invoiceId);
                    table.ForeignKey(
                        name: "FK_serviceDetails_items_itemId",
                        column: x => x.itemId,
                        principalTable: "items",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_serviceDetails_printingShops_printingShopId",
                        column: x => x.printingShopId,
                        principalTable: "printingShops",
                        principalColumn: "prentingShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    serviceId = table.Column<Guid>(nullable: false),
                    serviceTitle = table.Column<string>(maxLength: 100, nullable: false),
                    selectedSellUnitsellUnitId = table.Column<Guid>(nullable: true),
                    serviceDescreption = table.Column<string>(maxLength: 300, nullable: false),
                    ServiceDetailsinvoiceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.serviceId);
                    table.ForeignKey(
                        name: "FK_services_serviceDetails_ServiceDetailsinvoiceId",
                        column: x => x.ServiceDetailsinvoiceId,
                        principalTable: "serviceDetails",
                        principalColumn: "invoiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sellUnits",
                columns: table => new
                {
                    sellUnitId = table.Column<Guid>(nullable: false),
                    sellUnitName = table.Column<string>(maxLength: 200, nullable: false),
                    minimumNumber = table.Column<int>(maxLength: 200, nullable: false),
                    serviceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sellUnits", x => x.sellUnitId);
                    table.ForeignKey(
                        name: "FK_sellUnits_services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "services",
                        principalColumn: "serviceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_checkoutDetailes_orderId",
                table: "checkoutDetailes",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_courceMaterials_SubjectId",
                table: "courceMaterials",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_courceMaterials_printingShopId",
                table: "courceMaterials",
                column: "printingShopId");

            migrationBuilder.CreateIndex(
                name: "IX_deliverOptions_printingShopId",
                table: "deliverOptions",
                column: "printingShopId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_deliveryDrivers_printingShopprentingShopId",
                table: "deliveryDrivers",
                column: "printingShopprentingShopId");

            migrationBuilder.CreateIndex(
                name: "IX_documents_CustomerId",
                table: "documents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_CustomerId",
                table: "feedbacks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_orderId",
                table: "feedbacks",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_items_courceMaterialId",
                table: "items",
                column: "courceMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_items_documentdocId",
                table: "items",
                column: "documentdocId");

            migrationBuilder.CreateIndex(
                name: "IX_items_orderId",
                table: "items",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_items_printingShopId",
                table: "items",
                column: "printingShopId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_DeliveryDriverinvoiceId",
                table: "orders",
                column: "DeliveryDriverinvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_deliveryStatusStatusId",
                table: "orders",
                column: "deliveryStatusStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_orderStatusStatusId",
                table: "orders",
                column: "orderStatusStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_printingShops_addressinvoiceId",
                table: "printingShops",
                column: "addressinvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_printingShops_applicationUserId",
                table: "printingShops",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_printingShops_orderId",
                table: "printingShops",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_privatePromotionCodes_CustomerId",
                table: "privatePromotionCodes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_privatePromotionCodes_printingShopId",
                table: "privatePromotionCodes",
                column: "printingShopId");

            migrationBuilder.CreateIndex(
                name: "IX_problemReports_PrintingShopId",
                table: "problemReports",
                column: "PrintingShopId");

            migrationBuilder.CreateIndex(
                name: "IX_problemReports_adminId",
                table: "problemReports",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_publicPromotionCodes_printingShopId",
                table: "publicPromotionCodes",
                column: "printingShopId");

            migrationBuilder.CreateIndex(
                name: "IX_sellUnits_serviceId",
                table: "sellUnits",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceDetails_itemId",
                table: "serviceDetails",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceDetails_printingShopId",
                table: "serviceDetails",
                column: "printingShopId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceDetails_selectedServiceserviceId",
                table: "serviceDetails",
                column: "selectedServiceserviceId");

            migrationBuilder.CreateIndex(
                name: "IX_services_ServiceDetailsinvoiceId",
                table: "services",
                column: "ServiceDetailsinvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_services_selectedSellUnitsellUnitId",
                table: "services",
                column: "selectedSellUnitsellUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_suggestions_CustomerId",
                table: "suggestions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_suggestions_adminId",
                table: "suggestions",
                column: "adminId");

            migrationBuilder.AddForeignKey(
                name: "FK_printingShops_orders_orderId",
                table: "printingShops",
                column: "orderId",
                principalTable: "orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_serviceDetails_services_selectedServiceserviceId",
                table: "serviceDetails",
                column: "selectedServiceserviceId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_orders_orderId",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_printingShops_orders_orderId",
                table: "printingShops");

            migrationBuilder.DropForeignKey(
                name: "FK_courceMaterials_subjects_SubjectId",
                table: "courceMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_courceMaterials_printingShops_printingShopId",
                table: "courceMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_items_printingShops_printingShopId",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_serviceDetails_printingShops_printingShopId",
                table: "serviceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_customers_CustomerId",
                table: "documents");

            migrationBuilder.DropForeignKey(
                name: "FK_items_courceMaterials_courceMaterialId",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_items_documents_documentdocId",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_sellUnits_services_serviceId",
                table: "sellUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_serviceDetails_services_selectedServiceserviceId",
                table: "serviceDetails");

            migrationBuilder.DropTable(
                name: "checkoutDetailes");

            migrationBuilder.DropTable(
                name: "deliverOptions");

            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "privatePromotionCodes");

            migrationBuilder.DropTable(
                name: "problemReports");

            migrationBuilder.DropTable(
                name: "publicPromotionCodes");

            migrationBuilder.DropTable(
                name: "suggestions");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "deliveryDrivers");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "printingShops");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "applicationUsers");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "courceMaterials");

            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "serviceDetails");

            migrationBuilder.DropTable(
                name: "sellUnits");

            migrationBuilder.DropTable(
                name: "items");
        }
    }
}
