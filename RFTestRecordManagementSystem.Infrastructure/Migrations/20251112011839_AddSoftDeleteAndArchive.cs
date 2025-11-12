using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFTestRecordManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteAndArchive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                schema: "dbo",
                table: "RFTestRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "RFTestRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                schema: "dbo",
                table: "RFTestRecords");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "RFTestRecords");
        }
    }
}
