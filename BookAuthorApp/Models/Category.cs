using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthorApp.Models
{
	public class Category
	{
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required!")]
        public string CategoryName { get; set; }

        public List<BookCategoryMap> BookCategoryMaps { get; set; }
    }
}

