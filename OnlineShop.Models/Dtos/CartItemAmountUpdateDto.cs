using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.Dtos
{
	public class CartItemAmountUpdateDto
	{
		public int CartItemId { get; set; }
		public int Amount { get; set; }
	}
}
