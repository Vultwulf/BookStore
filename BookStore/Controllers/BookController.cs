using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/Book")]
    public class BookController : Controller
    {
        // GET: api/Book
        [HttpGet]
        public async Task<IEnumerable<BookEntity>> GetAsync()
        {
            IEnumerable<BookEntity> books = await BookEntity.GetAllAsync();
            return books;
        }

        // PUT: api/Book
        [HttpPut]
        public void Put([FromBody]BookDTO bookDTO)
        {
            BookEntity.MergeAsync(bookDTO);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody]BookDTO bookDTO)
        {
            BookEntity.CreateAsync(bookDTO);
        }
    }
}
