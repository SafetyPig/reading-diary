namespace ReadingDiary.DB.RepositoryInterfaces
{
    public interface IAuthorRepository
    {
        Task<int> AddAuthorAsync(string authorName);
    }
}
