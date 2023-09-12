using System;
namespace BookAuthorApp.Models
{
	public class BookCategoryMap
	{
		public int Book_Id { get; set; }
		public int Category_Id { get; set; }
		public Book Book { get; set; }
		public Category Category { get; set; }
	}
}

