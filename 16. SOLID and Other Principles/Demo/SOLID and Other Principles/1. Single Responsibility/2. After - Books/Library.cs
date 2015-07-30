namespace SingleResponsibilityBooksAfter
{
    using System.Collections.Generic;

    public class Library
    {
        private IList<Book> books;

        public Library()
        {
            this.books = new List<Book>();
        }

        public int FindBook(string title)
        {
            // logic for finding book
            return 42;
        }
    }
}
