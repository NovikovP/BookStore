using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art of Programming","ISBN 12312-21231", "Knuth"),
            new Book(2, "Refactoring","ISBN 12312-21232", "Fowler"),
            new Book(3, "C Programming Language","ISBN 12312-21233", "Kernigan"),
            new Book(4,"Popular programming","ISBN 12312-21234", "Over"),
            new Book(5," C#, .NET","ISBN 12312-21235", "Troelsen"),
            new Book(6,"C#","ISBN 12312-21236", "Shildt")
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn==isbn).ToArray();
        }

        //// TODO:  ???
        //public Book[] GetAllByTitle(string titlePart)
        //{
        //    return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        //}

        
        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            return books.Where(book => book.Title.Contains(titleOrAuthor) 
                                   || book.Autor.Contains(titleOrAuthor))
                .ToArray();
        }
    }
}
