using BookStore.Models;
using System;
using Xunit;

namespace BookStore.Tests
{
    public class BookEntityTest
    {
        [Fact]
        public void PopulateBookEntityWithBookDTO()
        {
            BookDTO bookDTO = new BookDTO
            {
                RowKey = "9780132350884",
                JacketUrl = "https://edel-images.azureedge.net/ea/PEAR/images/jacket_covers/original/0132350882_938ba.jpg",
                Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
                Series = "Robert C. Martin Series",
                Author = "Robert C.Martin",
                Price = 49.99
            };

            // Create the bookEntity from the bookDTO
            BookEntity bookEntity = new BookEntity(bookDTO);

            // Ensure the items match up
            Assert.Equal("partition1", bookEntity.PartitionKey);
            Assert.Equal(bookDTO.RowKey, bookEntity.RowKey);
            Assert.Equal(bookDTO.JacketUrl, bookEntity.JacketUrl);
            Assert.Equal(bookDTO.Title, bookEntity.Title);
            Assert.Equal(bookDTO.Series, bookEntity.Series);
            Assert.Equal(bookDTO.Author, bookEntity.Author);
            Assert.Equal(bookDTO.Price, bookEntity.Price);
            Assert.Equal("*", bookEntity.ETag);
        }
    }
}
