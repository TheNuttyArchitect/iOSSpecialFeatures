using Microsoft.EntityFrameworkCore.Migrations;

namespace iOSSpecialFeatures.MobileAppService.Migrations
{
    public partial class ChangeDataSetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "change_data_hash",
                columns: table => new
                {
                    change_data_hash_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    contacts_hash = table.Column<int>(nullable: false),
                    contact_phone_numbers_hash = table.Column<int>(nullable: false),
                    contact_email_addresses_hash = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_change_data_hash", x => x.change_data_hash_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "change_data_hash");
        }
    }
}
