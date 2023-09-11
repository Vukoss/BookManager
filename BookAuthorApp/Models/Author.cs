using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthorApp.Models
{
	public class Author
	{
		public int Author_Id { get; set; }

		public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Location { get; set; }

        public string FullName
        {
            get
            {
                return $"{Name} {LastName}";
            }
        }

        public List<BookAuthorMap> BookAuthorMap { get; set; }
    }
}

