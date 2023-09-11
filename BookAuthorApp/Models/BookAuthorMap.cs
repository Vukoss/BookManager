using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthorApp.Models
{
	public class BookAuthorMap
	{
		public int Book_Id { get; set; }

        public int Author_Id { get; set; }

		public Book Book { get; set; }

		public Author Author { get; set; }
	}
}

