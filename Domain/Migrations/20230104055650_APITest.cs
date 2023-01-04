using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class APITest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceCallLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCallUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ScenarioId = table.Column<int>(type: "int", nullable: true),
                    PBIId = table.Column<int>(type: "int", nullable: true),
                    TestCaseId = table.Column<int>(type: "int", nullable: true),
                    ServiceCallDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCallStatus = table.Column<bool>(type: "bit", nullable: true),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isSuccess = table.Column<bool>(type: "bit", nullable: false),
                    ExpectedResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedStatus = table.Column<int>(type: "int", nullable: false),
                    WronResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ErrorType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCallLog", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceCallLog");
        }
    }
}
