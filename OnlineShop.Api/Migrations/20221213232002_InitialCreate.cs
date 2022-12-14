using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "DishCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pizza" },
                    { 2, "Burger" },
                    { 3, "Drink" }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Amount", "CategoryId", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 600, 1, "Шампиньоны, грибной соус, красный лук, моцарелла, смесь сыров чеддер и пармезан, фирменный соус альфредо, чеснок", "/Images/Pizza/Mushroom.png", "Грибная", 629m },
                    { 2, 490, 1, "Моцарелла, сыры чеддер и пармезан, фирменный соус альфредо", "/Images/Pizza/Cheese.png", "Сырная", 479m },
                    { 3, 500, 1, "Ветчина, моцарелла, фирменный соус альфредо", "/Images/Pizza/HamAndCheese.png", "Ветчина и сыр", 479m },
                    { 4, 580, 1, "Пикантная пепперони, увеличенная порция моцареллы, фирменный томатный соус", "/Images/Pizza/Pepperoni.png", "Пепперони", 629m },
                    { 5, 640, 1, "Ветчина, ананасы, моцарелла, фирменный томатный соус", "/Images/Pizza/Hawaiian.png", "Гавайская", 629m },
                    { 6, 103, 2, "Рубленый бифштекс из натуральной цельной говядины на карамелизованной булочке, заправленной горчицей, кетчупом, луком и кусочком маринованного огурчика", "/Images/Burger/Hamburger.png", "Гамбургер", 55m },
                    { 7, 117, 2, "Рубленый бифштекс из натуральной цельной говядины с кусочками сыра Чеддер на карамелизованной булочке, заправленной горчицей, кетчупом, луком и кусочком маринованного огурчика", "/Images/Burger/Cheeseburger.png", "Чизбургер", 59m },
                    { 8, 129, 2, "Обжаренная куриная котлета из сочного куриного мяса, панированная в сухарях, которая подается на карамелизованной булочке, заправленной свежим салатом и специальным соусом", "/Images/Burger/Chickenburger.png", "Чикенбургер", 59m },
                    { 9, 250, 3, "Прохладительный газированный напиток 0,25 л", "/Images/Drink/Cola.png", "Добрый Кола", 79m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { 1, "Alexander" },
                    { 2, "Anvar" },
                    { 3, "Arthur" },
                    { 4, "Michael" },
                    { 5, "Anya" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "DishCategories");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
