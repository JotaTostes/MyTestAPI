using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hypoallergenic = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FemaleWeightMin = table.Column<int>(type: "int", nullable: false),
                    FemaleWeightMax = table.Column<int>(type: "int", nullable: false),
                    MaleWeightMin = table.Column<int>(type: "int", nullable: false),
                    MaleWeightMax = table.Column<int>(type: "int", nullable: false),
                    LifeMin = table.Column<int>(type: "int", nullable: false),
                    LifeMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breed");
        }
    }
}
