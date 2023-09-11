using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthorApp.Models
{
	public class BookDetail
	{
        public int BookDetail_Id { get; set; }

        [Required]
        public int NumberOfChapters { get; set; }

        public int NumberOfPages { get; set; }

        public string Weight { get; set; }

        public int Book_Id { get; set; }
        public Book Book { get; set; }
    }
}

