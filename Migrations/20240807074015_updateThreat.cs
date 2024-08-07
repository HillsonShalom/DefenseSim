using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefenseSim.Migrations
{
    /// <inheritdoc />
    public partial class updateThreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarrageCount",
                table: "threats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BarrageDelay",
                table: "threats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BarrageSize",
                table: "threats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarrageCount",
                table: "threats");

            migrationBuilder.DropColumn(
                name: "BarrageDelay",
                table: "threats");

            migrationBuilder.DropColumn(
                name: "BarrageSize",
                table: "threats");
        }
    }
}
