using System;
using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        public string Title { get; }

        public int Id { get; }

        public string Isbn { get; }

        public string Autor { get; }

        public Book(int id,string title, string isbn, string author)
        {
            Title = title;
            Id = id;
            Isbn = isbn;
            Autor = author;
        }

        internal static bool IsIsbn(string s)
        {
            if (s == null) {return false; }
            
            s = s.Replace("-", "")
                 .Replace(" ", "")
                 .ToUpper();
            return Regex.IsMatch(s, "^ISBN\\d{10}(\\d{3}?)$");
            // return Regex.IsMatch(s, "ISBN\\d{10}(\\d{3}?)");
            // return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3}?)&");
        }
    }
}
