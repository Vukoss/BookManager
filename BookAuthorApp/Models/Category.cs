using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthorApp.Models
{
	public class Category
	{
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<Book> Books { get; set; }
    }
}

