using System.Linq;
using CaribeMediaApi.DTOS;
using CaribeMediaApi.Entities;

namespace CaribeMediaApi.Extensions
{
    public static class DTOExtensions
    {
        public static BookDTO ToBookDTO(this Titles title, string author) => 
            new BookDTO
            {
                author = author,
                title = title.Title,
                type = title.Type,
                price = title.Price.HasValue ? title.Price.Value : -1,
                publishedOn = title.Pubdate
            };
        public static BookDTO ToBookDTO(this Titleauthor title) =>
            new BookDTO
            {
                title = title.Title.Title,
                type = title.Title.Type,
                price = title.Title.Price.HasValue ? title.Title.Price.Value : -1,
                publishedOn = title.Title.Pubdate
            };
        
        public static AuthorDTO ToAuthorDTO(this Authors author) =>
            new AuthorDTO
            {
                name = $"{author.AuFname} {author.AuLname}",
                TopBook =
                    author.Titleauthor
                        .OrderByDescending(by => by.Title.YtdSales)
                        .FirstOrDefault()
                        .ToBookDTO()
            };
       
    }
}