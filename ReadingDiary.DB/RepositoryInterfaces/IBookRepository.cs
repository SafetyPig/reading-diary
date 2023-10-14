using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDiary.DB.RepositoryInterfaces
{
    public interface IBookRepository
    {
        Task<int> AddBookAsync(string name, int authorId);

        Task<int> GetBookByTitleAsync(string name);
    }
}
