﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthorApp.Models
{
	public class Book
	{
		public int Book_Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public string PriceRange { get; set; }

        public BookDetail BookDetail { get; set; }

        public List<BookCategoryMap> BookCategoryMaps { get; set; }

        public int Publisher_Id { get; set; }
        public Publisher Publisher { get; set; }

        public List<BookAuthorMap> BookAuthorMap { get; set; }
    }
}

