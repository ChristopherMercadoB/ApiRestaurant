using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRestaurant.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeTheDeleteBehaviorToCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Ingrediente_IngredientId",
                table: "DishIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Plato_DishId",
                table: "DishIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Orden_OrderId",
                table: "OrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Plato_DishId",
                table: "OrderDish");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Ingrediente_IngredientId",
                table: "DishIngredient",
                column: "IngredientId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Plato_DishId",
                table: "DishIngredient",
                column: "DishId",
                principalTable: "Plato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Orden_OrderId",
                table: "OrderDish",
                column: "OrderId",
                principalTable: "Orden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Plato_DishId",
                table: "OrderDish",
                column: "DishId",
                principalTable: "Plato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Ingrediente_IngredientId",
                table: "DishIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Plato_DishId",
                table: "DishIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Orden_OrderId",
                table: "OrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Plato_DishId",
                table: "OrderDish");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Ingrediente_IngredientId",
                table: "DishIngredient",
                column: "IngredientId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Plato_DishId",
                table: "DishIngredient",
                column: "DishId",
                principalTable: "Plato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Orden_OrderId",
                table: "OrderDish",
                column: "OrderId",
                principalTable: "Orden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Plato_DishId",
                table: "OrderDish",
                column: "DishId",
                principalTable: "Plato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
