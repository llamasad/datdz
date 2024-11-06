using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcPaper.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaperType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaperDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    PaperTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Abstract = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaperDetail_PaperType_PaperTypeId",
                        column: x => x.PaperTypeId,
                        principalTable: "PaperType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaperDetail_PaperTypeId",
                table: "PaperDetail",
                column: "PaperTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaperDetail");

            migrationBuilder.DropTable(
                name: "PaperType");
        }
    }
}
