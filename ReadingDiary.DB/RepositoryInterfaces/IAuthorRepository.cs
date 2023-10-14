namespace ReadingDiary.DB.RepositoryInterfaces
{
    public interface IAuthorRepository
    {
        Task<int> AddAuthorAsync(string authorName);

        Task<int> GetAuthorByNameAsync(string authorName);
    }
}
