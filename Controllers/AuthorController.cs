using System.Collections.Generic;
using System.Threading.Tasks;
using CaribeMediaApi.DTOS;
using CaribeMediaApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaribeMediaApi.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger _logger;
        public AuthorController(
            IAuthorService authorService, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetBookBySales()
        {
            _logger.LogInformation("Getting author's books by sales");
            var books = await _authorService.GetAuthorsByBookSalesAsync();
            _logger.LogInformation("Books: {@books}", books);
            return Ok(books);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooksByAuthor(string name)
        {
            _logger.LogInformation("Getting books by author name {name}", name);
            var books = await _authorService.GetAuthorBooksByNameAsync(name);
            _logger.LogInformation("Books: {@books}", books);
            return Ok(books);
        }
 
    }
}