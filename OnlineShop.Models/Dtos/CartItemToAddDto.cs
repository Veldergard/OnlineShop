﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.Dtos
{
	public class CartItemToAddDto
	{
		public int CartId { get; set; }
		public int DishId { get; set; }
		public int Amount { get; set; }
	}
}
