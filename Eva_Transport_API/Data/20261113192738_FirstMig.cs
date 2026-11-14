using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eva_Transport_API.Data;

/// <inheritdoc />
public partial class _20261113192738_FirstMig : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "BusDrivers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                LicenseNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BusDrivers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Companies",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Companies", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "TruckDrivers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                LicenseNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TruckDrivers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Buses",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PlateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Capacity = table.Column<int>(type: "int", nullable: false),
                Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                CompanyId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Buses", x => x.Id);
                table.ForeignKey(
                    name: "FK_Buses_Companies_CompanyId",
                    column: x => x.CompanyId,
                    principalTable: "Companies",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Employees",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                PickupLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                CompanyId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.Id);
                table.ForeignKey(
                    name: "FK_Employees_Companies_CompanyId",
                    column: x => x.CompanyId,
                    principalTable: "Companies",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Trucks",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PlateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Capacity = table.Column<int>(type: "int", nullable: false),
                Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                CompanyId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Trucks", x => x.Id);
                table.ForeignKey(
                    name: "FK_Trucks_Companies_CompanyId",
                    column: x => x.CompanyId,
                    principalTable: "Companies",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "BusBusDriver",
            columns: table => new
            {
                busDriversId = table.Column<int>(type: "int", nullable: false),
                busesId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BusBusDriver", x => new { x.busDriversId, x.busesId });
                table.ForeignKey(
                    name: "FK_BusBusDriver_BusDrivers_busDriversId",
                    column: x => x.busDriversId,
                    principalTable: "BusDrivers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_BusBusDriver_Buses_busesId",
                    column: x => x.busesId,
                    principalTable: "Buses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "BusReports",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IssueDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                BusId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BusReports", x => x.Id);
                table.ForeignKey(
                    name: "FK_BusReports_Buses_BusId",
                    column: x => x.BusId,
                    principalTable: "Buses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "BusTrips",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                TripDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                BusId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BusTrips", x => x.Id);
                table.ForeignKey(
                    name: "FK_BusTrips_Buses_BusId",
                    column: x => x.BusId,
                    principalTable: "Buses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "TruckReports",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IssueDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                TruckId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TruckReports", x => x.Id);
                table.ForeignKey(
                    name: "FK_TruckReports_Trucks_TruckId",
                    column: x => x.TruckId,
                    principalTable: "Trucks",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "TruckTrips",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                TripDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                TruckId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TruckTrips", x => x.Id);
                table.ForeignKey(
                    name: "FK_TruckTrips_Trucks_TruckId",
                    column: x => x.TruckId,
                    principalTable: "Trucks",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "TruckTruckDriver",
            columns: table => new
            {
                truckDriversId = table.Column<int>(type: "int", nullable: false),
                trucksId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TruckTruckDriver", x => new { x.truckDriversId, x.trucksId });
                table.ForeignKey(
                    name: "FK_TruckTruckDriver_TruckDrivers_truckDriversId",
                    column: x => x.truckDriversId,
                    principalTable: "TruckDrivers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_TruckTruckDriver_Trucks_trucksId",
                    column: x => x.trucksId,
                    principalTable: "Trucks",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "BusTripEmployee",
            columns: table => new
            {
                employeeBusTripsId = table.Column<int>(type: "int", nullable: false),
                employeesId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BusTripEmployee", x => new { x.employeeBusTripsId, x.employeesId });
                table.ForeignKey(
                    name: "FK_BusTripEmployee_BusTrips_employeeBusTripsId",
                    column: x => x.employeeBusTripsId,
                    principalTable: "BusTrips",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_BusTripEmployee_Employees_employeesId",
                    column: x => x.employeesId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_BusBusDriver_busesId",
            table: "BusBusDriver",
            column: "busesId");

        migrationBuilder.CreateIndex(
            name: "IX_Buses_CompanyId",
            table: "Buses",
            column: "CompanyId");

        migrationBuilder.CreateIndex(
            name: "IX_BusReports_BusId",
            table: "BusReports",
            column: "BusId");

        migrationBuilder.CreateIndex(
            name: "IX_BusTripEmployee_employeesId",
            table: "BusTripEmployee",
            column: "employeesId");

        migrationBuilder.CreateIndex(
            name: "IX_BusTrips_BusId",
            table: "BusTrips",
            column: "BusId");

        migrationBuilder.CreateIndex(
            name: "IX_Employees_CompanyId",
            table: "Employees",
            column: "CompanyId");

        migrationBuilder.CreateIndex(
            name: "IX_TruckReports_TruckId",
            table: "TruckReports",
            column: "TruckId");

        migrationBuilder.CreateIndex(
            name: "IX_Trucks_CompanyId",
            table: "Trucks",
            column: "CompanyId");

        migrationBuilder.CreateIndex(
            name: "IX_TruckTrips_TruckId",
            table: "TruckTrips",
            column: "TruckId");

        migrationBuilder.CreateIndex(
            name: "IX_TruckTruckDriver_trucksId",
            table: "TruckTruckDriver",
            column: "trucksId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "BusBusDriver");

        migrationBuilder.DropTable(
            name: "BusReports");

        migrationBuilder.DropTable(
            name: "BusTripEmployee");

        migrationBuilder.DropTable(
            name: "TruckReports");

        migrationBuilder.DropTable(
            name: "TruckTrips");

        migrationBuilder.DropTable(
            name: "TruckTruckDriver");

        migrationBuilder.DropTable(
            name: "BusDrivers");

        migrationBuilder.DropTable(
            name: "BusTrips");

        migrationBuilder.DropTable(
            name: "Employees");

        migrationBuilder.DropTable(
            name: "TruckDrivers");

        migrationBuilder.DropTable(
            name: "Trucks");

        migrationBuilder.DropTable(
            name: "Buses");

        migrationBuilder.DropTable(
            name: "Companies");
    }
}
