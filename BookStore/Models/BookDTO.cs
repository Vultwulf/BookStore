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
    /// Object used to send data from the client to the server.
    /// </summary>
    public class BookDTO
    {
        /// <summary>
        /// Gets or sets the rowKey (ISBN) of the book.
        /// </summary>
        [JsonProperty(PropertyName = "rowKey")]
        public string RowKey { get; set; }

        /// <summary>
        /// Gets or sets the image url of the jacket cover of a book.
        /// </summary>
        [JsonProperty(PropertyName = "jacketUrl")]
        public string JacketUrl { get; set; }

        /// <summary>
        /// Gets or sets the title of a book.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the series of a book.
        /// </summary>
        [JsonProperty(PropertyName = "series")]
        public string Series { get; set; }

        /// <summary>
        /// Gets or sets the author of a book.
        /// </summary>
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the price of a book.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
        
    }
}
