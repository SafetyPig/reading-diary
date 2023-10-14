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

            await _context.SaveChangesAsync();
            return author.Id;
        }

        public async Task<int> GetAuthorByNameAsync(string authorName)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Name.ToLower() == authorName.ToLower());
            
            if (author == null)
            {
                return 0;
            }

            await _context.SaveChangesAsync();

            return author.Id;
        }
    }
}
