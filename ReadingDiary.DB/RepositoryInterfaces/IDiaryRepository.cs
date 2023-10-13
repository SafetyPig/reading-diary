using ReadingDiary.DB.Models;

namespace ReadingDiary.DB.RepositoryInterfaces
{
    public interface IDiaryRepository
    {
        Task<Diary?> GetByIdAsync(int diaryId);

        Task<DiaryEntry> AddDiaryEntryAsync(DiaryEntry diaryEntry);
    }
}
