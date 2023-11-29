using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bags_Accessories.Migrations
{
    /// <inheritdoc />
    public partial class OrderClientUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "orderClients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderClients_UserId",
                table: "orderClients",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderClients_AspNetUsers_UserId",
                table: "orderClients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderClients_AspNetUsers_UserId",
                table: "orderClients");

            migrationBuilder.DropIndex(
                name: "IX_orderClients_UserId",
                table: "orderClients");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "orderClients");
        }
    }
}
