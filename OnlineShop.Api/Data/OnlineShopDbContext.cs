using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Entities;

namespace OnlineShop.Api.Data
{
	public class OnlineShopDbContext : DbContext
	{
		public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Dishes
			//Pizza Category
			modelBuilder.Entity<Dish>().HasData(new Dish
			{
				Id = 1,
				Name = "Грибная",
				Description = "Шампиньоны, грибной соус, красный лук, моцарелла, смесь сыров чеддер и пармезан, фирменный соус альфредо, чеснок",
				ImageURL = "/Images/Pizza/Mushroom.png",
				Price = 629,
				Amount = 600,
				CategoryId = 1
			});
			modelBuilder.Entity<Dish>().HasData(new Dish
			{
				Id = 2,
				Name = "Сырная",
				Description = "Моцарелла, сыры чеддер и пармезан, фирменный соус альфредо",
				ImageURL = "/Images/Pizza/Cheese.png",
				Price = 479,
				Amount = 490,
				CategoryId = 1
			});
			modelBuilder.Entity<Dish>().HasData(new Dish
			{
				Id = 3,
				Name = "Ветчина и сыр",
				Description = "Ветчина, моцарелла, фирменный соус альфредо",
				ImageURL = "/Images/Pizza/HamAndCheese.png",
				Price = 479,
				Amount = 500,
				CategoryId = 1
			});
			modelBuilder.Entity<Dish>().HasData(new Dish
			{
				Id = 4,
				Name = "Пепперони",
				Description = "Пикантная пепперони, увеличенная порция моцареллы, фирменный томатный соус",
				ImageURL = "/Images/Pizza/Pepperoni.png",
				Price = 629,
				Amount = 580,
				CategoryId = 1
			});
			modelBuilder.Entity<Dish>().HasData(new Dish
			{
				Id = 5,
				Name = "Гавайская",
				Description = "Ветчина, ананасы, моцарелла, фирменный томатный соус",
				ImageURL = "/Images/Pizza/Hawaiian.png",
				Price = 629,
				Amount = 640,
				CategoryId = 1
			});

			//Burger Category
			modelBuilder.Entity<Dish>().HasData(new Dish
			{
				Id = 6,
				Name = "Гамбургер",
				Description = "Рубленый бифштекс из натуральной цельной говядины на карамелизованной булочке, заправленной горчицей, кетчупом, луком и кусочком маринованного огурчика",
				ImageURL = "/Images/Burger/Hamburger.png",
				Price = 55,
				Amount = 103,
				CategoryId = 2
			});
			modelBuilder.Entity<Dish>().HasData(new Dish
			{
				Id = 7,
				Name = "Чизбургер",
				Description = "Рубленый бифштекс из натуральной цельной говядины с кусочками сыра Чеддер на карамелизованной булочке, заправленной горчицей, кетчупом, луком и кусочком маринованного огурчика",
				ImageURL = "/Images/Burger/Cheeseburger.png",
				Price = 59,
				Amount = 117,
				CategoryId = 2
			});
			modelBuilder.Entity<Dish>().HasData(new Dish
			{
				Id = 8,
				Name = "Чикенбургер",
				Description = "Обжаренная куриная котлета из сочного куриного мяса, панированная в сухарях, которая подается на карамелизованной булочке, заправленной свежим салатом и специальным соусом",
				ImageURL = "/Images/Burger/Chickenburger.png",
				Price = 59,
				Amount = 129,
				CategoryId = 2
			});

			//Drink Category
			modelBuilder.Entity<Dish>().HasData(new Dish
			{
				Id = 9,
				Name = "Добрый Кола",
				Description = "Прохладительный газированный напиток 0,25 л",
				ImageURL = "/Images/Drink/Cola.png",
				Price = 79,
				Amount = 250,
				CategoryId = 3
			});

			//Add users
			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 1,
				UserName = "Alexander"
			});
			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 2,
				UserName = "Anvar"
			});
			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 3,
				UserName = "Arthur"
			});
			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 4,
				UserName = "Michael"
			});
			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 5,
				UserName = "Anya"
			});

			//Create Shopping Cart for Users
			modelBuilder.Entity<Cart>().HasData(new Cart
			{
				Id = 1,
				UserId = 1

			});
			modelBuilder.Entity<Cart>().HasData(new Cart
			{
				Id = 2,
				UserId = 2
			});
			modelBuilder.Entity<Cart>().HasData(new Cart
			{
				Id = 3,
				UserId = 3
			});
			modelBuilder.Entity<Cart>().HasData(new Cart
			{
				Id = 4,
				UserId = 4
			});
			modelBuilder.Entity<Cart>().HasData(new Cart
			{
				Id = 5,
				UserId = 5
			});

			//Add Dish Categories
			modelBuilder.Entity<DishCategory>().HasData(new DishCategory
			{
				Id = 1,
				Name = "Pizza"
			});
			modelBuilder.Entity<DishCategory>().HasData(new DishCategory
			{
				Id = 2,
				Name = "Burger"
			});
			modelBuilder.Entity<DishCategory>().HasData(new DishCategory
			{
				Id = 3,
				Name = "Drink"
			});
		}

		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Dish> Dishes { get; set; }
		public DbSet<DishCategory> DishCategories { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
