using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFTestRecordManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "RFTestRecords",
                schema: "dbo",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Regulation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RadioTechnology = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Band = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PowerDbm = table.Column<decimal>(type: "decimal(6,3)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFTestRecords", x => x.RecordId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFTestRecords",
                schema: "dbo");
        }
    }
}
