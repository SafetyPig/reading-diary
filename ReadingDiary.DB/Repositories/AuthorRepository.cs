using Microsoft.EntityFrameworkCore;
using ReadingDiary.DB.Models;
using ReadingDiary.DB.RepositoryInterfaces;

namespace ReadingDiary.DB.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ReadingDiaryContext _context;

        public AuthorRepository(ReadingDiaryContext context)
        {
            _context = context;
        }

        public async Task<int> AddAuthorAsync(string authorName)
        {
            var author = new Author { Name = authorName }; 
            await _context.Authors.AddAsync(author);
            return author.Id;
        }
    }
}
