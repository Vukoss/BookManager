using System;
using System.ComponentModel.DataAnnotations;

namespace BookAuthorApp.Pages
{
	public class CategoryVM
	{
		[Required]
		public string CategoryName { get; set; }
	}
}

