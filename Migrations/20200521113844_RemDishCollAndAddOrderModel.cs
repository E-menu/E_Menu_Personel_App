using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Menu_Personel_App.Migrations
{
    public partial class RemDishCollAndAddOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Tables_TableID",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_TableID",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "TableID",
                table: "Dishes");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishID = table.Column<int>(nullable: false),
                    TableID = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "TableID",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_TableID",
                table: "Dishes",
                column: "TableID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Tables_TableID",
                table: "Dishes",
                column: "TableID",
                principalTable: "Tables",
                principalColumn: "TableID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
