using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaribeMediaApi.Data;
using CaribeMediaApi.DTOS;
using CaribeMediaApi.Extensions;
using CaribeMediaApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaribeMediaApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly PubsContext _dbContext;
        public AuthorService(PubsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<BookDTO>> GetAuthorsTopBooksAsync(Pagination pagination = null) =>
            _dbContext
                .Authors
                    .AsNoTracking()
                    .Include(i => i.Titleauthor)
                        .ThenInclude(i => i.Title)
                    .Where(w => w.Titleauthor.Any(a => a.Title.YtdSales.HasValue))
                    .Paginate(pagination)
                    .OrderBy(by => by.AuId)
                    .Select(s => s.GetTopBookDTO())
                    .ToListAsync();
                    
        public Task<List<BookDTO>> GetAuthorBooksByNameAsync(string author, Pagination pagination = null) =>
            _dbContext
                .Titles
                    .AsNoTracking()
                    .Include(i => i.Titleauthor)
                        .ThenInclude(i => i.Au)
                    .Where(title => title.Titleauthor.Any(
                        a => string.Equals(
                            a.Au.AuFname.Trim(), author.Trim(), StringComparison.OrdinalIgnoreCase)
                    ))
                    .Paginate(pagination)
                    .OrderBy(by => by.TitleId)
                    .Select(title => title.ToBookDTO(author))
                    .ToListAsync();  
    }
}