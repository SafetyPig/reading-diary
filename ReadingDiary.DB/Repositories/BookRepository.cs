using ReadingDiary.DB.Models;
using ReadingDiary.DB.RepositoryInterfaces;

namespace ReadingDiary.DB.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ReadingDiaryContext _context;

        public BookRepository(ReadingDiaryContext context)
        {
            _context = context;
        }

        public async Task<int> AddBookAsync(string name, int authorId)
        {
            if (await _context.Authors.FindAsync(authorId) == null) 
            {
                throw new InvalidOperationException("Author not found"); // TODO: Make new exception type and throw that 
            }

            var newBook = new Book
            {
                AuthorId = authorId,
                Title = name
            };

            await _context.Books.AddAsync(newBook);

            return newBook.Id;
        }
    }
}
