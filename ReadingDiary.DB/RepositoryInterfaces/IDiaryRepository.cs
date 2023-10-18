using ReadingDiary.DB.Models;

namespace ReadingDiary.DB.RepositoryInterfaces
{
    public interface IDiaryRepository
    {
        Task<Diary?> GetByIdAsync(int diaryId);

        Task<DiaryEntry> GetDiaryEntryByIdAsync(int diaryEntryId);

        Task<DiaryEntry> AddDiaryEntryAsync(DiaryEntry diaryEntry);

        Task<DiaryEntry> UpdateDiaryEntryAsync(DiaryEntry diaryEntry);
    }
}
