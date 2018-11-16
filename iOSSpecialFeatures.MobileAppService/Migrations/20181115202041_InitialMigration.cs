using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iOSSpecialFeatures.MobileAppService.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    created_date = table.Column<DateTime>(nullable: false),
                    last_modified_date = table.Column<DateTime>(nullable: true),
                    contact_id = table.Column<Guid>(nullable: false),
                    first_name = table.Column<string>(maxLength: 30, nullable: false),
                    middle_name = table.Column<string>(maxLength: 30, nullable: true),
                    last_name = table.Column<string>(maxLength: 30, nullable: false),
                    nick_name = table.Column<string>(maxLength: 30, nullable: true),
                    is_friend = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.contact_id);
                });

            migrationBuilder.CreateTable(
                name: "contact_email",
                columns: table => new
                {
                    created_date = table.Column<DateTime>(nullable: false),
                    last_modified_date = table.Column<DateTime>(nullable: true),
                    contact_email_id = table.Column<Guid>(nullable: false),
                    contact_id = table.Column<Guid>(nullable: false),
                    email_address = table.Column<string>(maxLength: 255, nullable: false),
                    phone_type = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_email", x => x.contact_email_id);
                    table.ForeignKey(
                        name: "FK_contact_email_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "contact_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contact_phone",
                columns: table => new
                {
                    created_date = table.Column<DateTime>(nullable: false),
                    last_modified_date = table.Column<DateTime>(nullable: true),
                    contact_phone_id = table.Column<Guid>(nullable: false),
                    contact_id = table.Column<Guid>(nullable: false),
                    phone_number = table.Column<string>(maxLength: 15, nullable: false),
                    phone_type = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_phone", x => x.contact_phone_id);
                    table.ForeignKey(
                        name: "FK_contact_phone_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "contact_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contact_email_contact_id",
                table: "contact_email",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "IX_contact_phone_contact_id",
                table: "contact_phone",
                column: "contact_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact_email");

            migrationBuilder.DropTable(
                name: "contact_phone");

            migrationBuilder.DropTable(
                name: "contact");
        }
    }
}
