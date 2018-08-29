using System.Collections.Generic;
using System.Threading.Tasks;
using CaribeMediaApi.DTOS;
using CaribeMediaApi.Extensions;

namespace CaribeMediaApi.Interfaces
{
    public interface IAuthorService
    {
        Task<List<BookDTO>> GetAuthorsTopBooksAsync(Pagination pagination = null);
        Task<List<BookDTO>> GetAuthorBooksByNameAsync(string authorName, Pagination pagination = null);
    }
}