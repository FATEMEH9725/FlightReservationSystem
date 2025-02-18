using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightReservationSystem.DbMigrate.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Flight");

            migrationBuilder.CreateTable(
                name: "AirlineAgency",
                schema: "Flight",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AirLineCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineAgency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "Flight",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Flight",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalCode = table.Column<string>(type: "char(10)", nullable: false),
                    MobileNumber = table.Column<string>(type: "char(11)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(200)", nullable: false),
                    BirthDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RoleType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                schema: "Flight",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineAgency_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginCity_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationCity_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartureTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ArrivalTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SeatsCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CabinClassType = table.Column<int>(type: "int", nullable: false),
                    AircraftModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoAllowance = table.Column<int>(type: "int", nullable: false),
                    TerminalType = table.Column<int>(type: "int", nullable: false),
                    FlightType = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_AirlineAgency_AirlineAgency_Id",
                        column: x => x.AirlineAgency_Id,
                        principalSchema: "Flight",
                        principalTable: "AirlineAgency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_City_DestinationCity_Id",
                        column: x => x.DestinationCity_Id,
                        principalSchema: "Flight",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_City_OriginCity_Id",
                        column: x => x.OriginCity_Id,
                        principalSchema: "Flight",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAuthentication",
                schema: "Flight",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VerifyCode = table.Column<int>(type: "int", nullable: true),
                    ExpireDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuthentication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAuthentication_User_User_Id",
                        column: x => x.User_Id,
                        principalSchema: "Flight",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketsBooked",
                schema: "Flight",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Flight_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsBooked", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketsBooked_Flight_Flight_Id",
                        column: x => x.Flight_Id,
                        principalSchema: "Flight",
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketsBooked_User_User_Id",
                        column: x => x.User_Id,
                        principalSchema: "Flight",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineAgency_Id",
                schema: "Flight",
                table: "Flight",
                column: "AirlineAgency_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinationCity_Id",
                schema: "Flight",
                table: "Flight",
                column: "DestinationCity_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_OriginCity_Id",
                schema: "Flight",
                table: "Flight",
                column: "OriginCity_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsBooked_Flight_Id",
                schema: "Flight",
                table: "TicketsBooked",
                column: "Flight_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsBooked_User_Id",
                schema: "Flight",
                table: "TicketsBooked",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthentication_User_Id",
                schema: "Flight",
                table: "UserAuthentication",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketsBooked",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "UserAuthentication",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Flight",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "AirlineAgency",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Flight");
        }
    }
}
