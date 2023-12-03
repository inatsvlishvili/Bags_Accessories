using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bags_Accessories.Migrations
{
    /// <inheritdoc />
    public partial class ClientOrderNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderClients_Accessories_AccessorieID",
                table: "OrderClients");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderClients_Bags_BagID",
                table: "OrderClients");

            migrationBuilder.AlterColumn<int>(
                name: "BagID",
                table: "OrderClients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AccessorieID",
                table: "OrderClients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderClients_Accessories_AccessorieID",
                table: "OrderClients",
                column: "AccessorieID",
                principalTable: "Accessories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderClients_Bags_BagID",
                table: "OrderClients",
                column: "BagID",
                principalTable: "Bags",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderClients_Accessories_AccessorieID",
                table: "OrderClients");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderClients_Bags_BagID",
                table: "OrderClients");

            migrationBuilder.AlterColumn<int>(
                name: "BagID",
                table: "OrderClients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccessorieID",
                table: "OrderClients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderClients_Accessories_AccessorieID",
                table: "OrderClients",
                column: "AccessorieID",
                principalTable: "Accessories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderClients_Bags_BagID",
                table: "OrderClients",
                column: "BagID",
                principalTable: "Bags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
