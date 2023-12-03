using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bags_Accessories.Migrations
{
    /// <inheritdoc />
    public partial class CommentClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentTXT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BagID = table.Column<int>(type: "int", nullable: false),
                    AccessorieID = table.Column<int>(type: "int", nullable: false),
                    CreatedateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Accessories_AccessorieID",
                        column: x => x.AccessorieID,
                        principalTable: "Accessories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Bags_BagID",
                        column: x => x.BagID,
                        principalTable: "Bags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AccessorieID",
                table: "Comment",
                column: "AccessorieID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BagID",
                table: "Comment",
                column: "BagID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");
        }
    }
}
