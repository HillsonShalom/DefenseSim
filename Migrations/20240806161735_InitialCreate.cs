using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefenseSim.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureType = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterceptTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponseType = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    CounterMeasure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "threats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    LaunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    ResponseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_threats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_threats_locations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_threats_locations_OriginId",
                        column: x => x.OriginId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_threats_responses_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "responses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_threats_weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_threats_DestinationId",
                table: "threats",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_threats_OriginId",
                table: "threats",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_threats_ResponseId",
                table: "threats",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_threats_WeaponId",
                table: "threats",
                column: "WeaponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "threats");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "weapons");
        }
    }
}
