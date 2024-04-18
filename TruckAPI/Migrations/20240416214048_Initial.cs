using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Registration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrossWeight = table.Column<double>(type: "float", nullable: false),
                    TareWeight = table.Column<double>(type: "float", nullable: false),
                    NetWeight = table.Column<double>(type: "float", nullable: false),
                    Haulier = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trucks");
        }
    }
}
