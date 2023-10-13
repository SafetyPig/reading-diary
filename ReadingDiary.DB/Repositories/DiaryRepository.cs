using Microsoft.EntityFrameworkCore;
using ReadingDiary.DB.Models;
using ReadingDiary.DB.RepositoryInterfaces;

namespace ReadingDiary.DB.Repositories
{
    public class DiaryRepository : IDiaryRepository
    {        
        private readonly ReadingDiaryContext _context;
        
        public DiaryRepository(ReadingDiaryContext context)
        {
            _context = context;
        }

        public async Task<DiaryEntry> AddDiaryEntryAsync(DiaryEntry diaryEntry)
        {
            await _context.DiaryEntries.AddAsync(diaryEntry);
            return diaryEntry;
        }

        public async Task<Diary?> GetByIdAsync(int diaryId)
        {
            return await _context.Diaries.SingleOrDefaultAsync(d => d.Id == diaryId);
        }
    }
}
