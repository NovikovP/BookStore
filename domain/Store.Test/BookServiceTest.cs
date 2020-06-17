using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using NuGet.Frameworks;

namespace Store.Test
{
    public class BookServiceTest
    {
        [Fact]
        public void GetAllByQuerry_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();

            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] {new Book(1, "", "", "")});

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositoryStub.Object);
            var valid = "ISBN 12345-67890";
            var actual = bookService.GetAllByQuery(valid);

            Assert.Collection(actual, book => AssetTargetFallbackFramework.Equals(1, book.Id));
        }

        [Fact]
        public void GetAllByQuerry_WithIsbn_CallsGetAllByTitleOrAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "") });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositoryStub.Object);
            var invalid = "ISBN 12345-67890";
            var actual = bookService.GetAllByQuery(invalid);

            Assert.Collection(actual, book => AssetTargetFallbackFramework.Equals(2, book.Id));
        }
    }
}
