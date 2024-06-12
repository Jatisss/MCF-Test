using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bpkp_be.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ms_storage_location",
                columns: table => new
                {
                    LocationId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ms_storage_location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "ms_user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ms_user", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tr_bpkp",
                columns: table => new
                {
                    AgreementNumber = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BpkbNo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BranchId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    BpkbDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FakturNo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FakturDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PoliceNo = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    BpkbDateIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_bpkp", x => x.AgreementNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ms_storage_location");

            migrationBuilder.DropTable(
                name: "ms_user");

            migrationBuilder.DropTable(
                name: "tr_bpkp");
        }
    }
}
