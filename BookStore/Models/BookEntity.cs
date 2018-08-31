using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    /// <summary>
    /// Entity Model for accessing the Azure Cosmos DB Book Table
    /// </summary>
    public class BookEntity : TableEntity
    {
        /// <summary>
        /// Table name
        /// </summary>
        private const string PK = "Books";

        /// <summary>
        /// Connection string
        /// </summary>
        private const string ConnectionStringConfig = "DefaultEndpointsProtocol=https;AccountName=bookstoredb;AccountKey=rOsF8URJRYWeVabaiOivBxT95RRR6fjUrcAwLQSI8x8siKcjnBA9Ll3Lm0DUnFTRAHqcBXUqRT93rAWadP8rSg==;TableEndpoint=https://bookstoredb.table.cosmosdb.azure.com:443/;";

        /// <summary>
        /// Gets or sets the image url of the jacket cover of a book.
        /// </summary>
        public string JacketUrl { get; set; }

        /// <summary>
        /// Gets or sets the title of a book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the series of a book.
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Gets or sets the author of a book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the price of a book.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Populate a BookEntity object with the BookDTO object.
        /// </summary>
        /// <param name="book">The BookDTO object</param>
        public BookEntity(BookDTO bookDTO)
        {
            this.PartitionKey = "partition1";
            this.RowKey = bookDTO.RowKey;
            this.JacketUrl = bookDTO.JacketUrl;
            this.Title = bookDTO.Title;
            this.Series = bookDTO.Series;
            this.Author = bookDTO.Author;
            this.Price = bookDTO.Price;
            this.ETag = "*";
        }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public BookEntity() { }

        /// <summary>
        /// Async method to create the Book table if it doesn't exist.
        /// </summary>
        async void CreateBookTableAsync()
        {
            // Create the CloudTable if it does not exist
            CloudTable bookTable = GetTable();
            await bookTable.CreateIfNotExistsAsync();
        }

        /// <summary>
        /// Insert a new entity into the Book table
        /// </summary>
        /// <param name="bookDTO">The BookDTO object</param>
        public static async void CreateAsync(BookDTO bookDTO)
        {
            CloudTable bookTable = GetTable();
            await bookTable.CreateIfNotExistsAsync();

            BookEntity bookEntity = new BookEntity(bookDTO);

            // Create the TableOperation that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(bookEntity);

            // Execute the insert operation.
            await bookTable.ExecuteAsync(insertOperation);
        }

        /// <summary>
        /// Merge changes into an existing Book entity.
        /// </summary>
        /// <param name="bookDTO">The BookDTO object</param>
        public static async void MergeAsync(BookDTO bookDTO)
        {
            CloudTable bookTable = GetTable();
            await bookTable.CreateIfNotExistsAsync();

            BookEntity bookEntity = new BookEntity(bookDTO);

            // Create the TableOperation that inserts the customer entity.
            TableOperation mergeOperation = TableOperation.Merge(bookEntity);

            // Execute the insert operation.
            await bookTable.ExecuteAsync(mergeOperation);
        }

        /// <summary>
        /// Retrieve all BookEntity objects from the Book table
        /// </summary>
        public static async Task<List<BookEntity>> GetAllAsync()
        {
            CloudTable bookTable = GetTable();
            await bookTable.CreateIfNotExistsAsync();

            TableQuery<BookEntity> query = new TableQuery<BookEntity>();
            TableContinuationToken token = null;
            List<BookEntity> books = new List<BookEntity>();

            do
            {
                TableQuerySegment<BookEntity> resultSegment = await bookTable.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;
                books.AddRange(resultSegment.Results);
            } while (token != null);

            return books;
        }

        /// <summary>
        /// Get the Book table object.
        /// </summary>
        private static CloudTable GetTable()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionStringConfig);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            return tableClient.GetTableReference(PK);
        }
    }
}
