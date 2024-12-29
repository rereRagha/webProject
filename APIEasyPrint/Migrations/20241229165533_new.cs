using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPrintWebSite.Migrations.StucturDb
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "suggestions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeatcherId",
                table: "suggestions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "parents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_parents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teatchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_teatchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "globalNotifications",
                columns: table => new
                {
                    globalNotificationId = table.Column<Guid>(nullable: false),
                    notificationTitle = table.Column<string>(maxLength: 100, nullable: false),
                    notificationDescription = table.Column<string>(maxLength: 500, nullable: false),
                    notificationDate = table.Column<DateTime>(nullable: false),
                    teatcherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_globalNotifications", x => x.globalNotificationId);
                    table.ForeignKey(
                        name: "FK_globalNotifications_teatchers_teatcherId",
                        column: x => x.teatcherId,
                        principalTable: "teatchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    notificationId = table.Column<Guid>(nullable: false),
                    notificationTitle = table.Column<string>(maxLength: 100, nullable: false),
                    notificationDescription = table.Column<string>(maxLength: 500, nullable: false),
                    notificationDate = table.Column<DateTime>(nullable: false),
                    teatcherId = table.Column<Guid>(nullable: false),
                    parentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.notificationId);
                    table.ForeignKey(
                        name: "FK_notifications_parents_parentId",
                        column: x => x.parentId,
                        principalTable: "parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notifications_teatchers_teatcherId",
                        column: x => x.teatcherId,
                        principalTable: "teatchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_suggestions_ParentId",
                table: "suggestions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_suggestions_TeatcherId",
                table: "suggestions",
                column: "TeatcherId");

            migrationBuilder.CreateIndex(
                name: "IX_globalNotifications_teatcherId",
                table: "globalNotifications",
                column: "teatcherId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_parentId",
                table: "notifications",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_teatcherId",
                table: "notifications",
                column: "teatcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_suggestions_parents_ParentId",
                table: "suggestions",
                column: "ParentId",
                principalTable: "parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_suggestions_teatchers_TeatcherId",
                table: "suggestions",
                column: "TeatcherId",
                principalTable: "teatchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_suggestions_parents_ParentId",
                table: "suggestions");

            migrationBuilder.DropForeignKey(
                name: "FK_suggestions_teatchers_TeatcherId",
                table: "suggestions");

            migrationBuilder.DropTable(
                name: "globalNotifications");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "parents");

            migrationBuilder.DropTable(
                name: "teatchers");

            migrationBuilder.DropIndex(
                name: "IX_suggestions_ParentId",
                table: "suggestions");

            migrationBuilder.DropIndex(
                name: "IX_suggestions_TeatcherId",
                table: "suggestions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "suggestions");

            migrationBuilder.DropColumn(
                name: "TeatcherId",
                table: "suggestions");
        }
    }
}
