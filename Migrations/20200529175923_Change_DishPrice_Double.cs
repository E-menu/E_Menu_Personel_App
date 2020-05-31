using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Menu_Personel_App.Migrations
{
    public partial class Change_DishPrice_Double : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DishPrice",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DishPrice",
                table: "Dishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
