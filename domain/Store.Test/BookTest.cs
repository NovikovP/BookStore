using System;
using Xunit;

namespace Store.Test
{
    public class BookTest
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);
            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithBlancString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("  ");
            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISBN 123");
            Assert.False(actual);
        }

        //[Fact]
        //public void IsIsbn_WithIsbn10_ReturnTrue()
        //{
        //    bool actual = Book.IsIsbn("ISBN 123-321-345 8");
        //    Assert.True(actual);
        //}

        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 123-456-789 1234");
            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbnTrashStart_ReturnFalse()
        {
            bool actual = Book.IsIsbn("xxx ISBN 123-456-789 123 yyy");
            Assert.False(actual);
        }
    }
}
