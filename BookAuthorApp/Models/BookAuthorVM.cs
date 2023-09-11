using System;
namespace BookAuthorApp.Models
{
	public class BookAuthorVM
	{
		//nowo utworzony i przypisany do ksiazki obiekt BookAuthorMap z Id dla ksiazki i Id dla autora
		public BookAuthorMap BookAuthor { get; set; }

		//ksiązka
		public Book Book { get; set; }

		// Lista autorów przypisanych juz do ksiazki
		public IEnumerable<BookAuthorMap> BookAuthorList { get; set; }

		//Lista autorow ktorzy dostępni sa do bycia przypisanym do książki - czyli autorzy, których nie ma w BookAuthorList
		public IEnumerable<Author> AuthorList { get; set; }
	}
}

