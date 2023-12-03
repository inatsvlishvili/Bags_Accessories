using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bags_Accessories.Migrations
{
    /// <inheritdoc />
    public partial class ContactAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Bags",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    CommentTXT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderClients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasportID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentTXT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BagID = table.Column<int>(type: "int", nullable: false),
                    AccessorieID = table.Column<int>(type: "int", nullable: false),
                    CreatedateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderClients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderClients_Accessories_AccessorieID",
                        column: x => x.AccessorieID,
                        principalTable: "Accessories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderClients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderClients_Bags_BagID",
                        column: x => x.BagID,
                        principalTable: "Bags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderClients_AccessorieID",
                table: "OrderClients",
                column: "AccessorieID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderClients_BagID",
                table: "OrderClients",
                column: "BagID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderClients_UserId",
                table: "OrderClients",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "OrderClients");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Bags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
