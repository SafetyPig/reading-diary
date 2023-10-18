using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using ReadingDiary.APImodels;
using ReadingDiary.DB.Models;
using ReadingDiary.DB.Repositories;
using ReadingDiary.DB.RepositoryInterfaces;

namespace ReadingDiary.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(scopeRequiredByAPI)]
    public class DiaryController : ControllerBase
    {
        const string scopeRequiredByAPI = "reading-diary.read";

        private readonly ILogger<DiaryController> _logger;
        private readonly IDiaryRepository _repository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public DiaryController(ILogger<DiaryController> logger, IDiaryRepository repository, IAuthorRepository authorRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns asked Diary
        /// </summary>
        /// <returns>Asked diary</returns>
        [HttpGet(Name = "GetDiary")]
        public async Task<ActionResult<DiaryDTO>> Get(int id)
        {
            var diary = await _repository.GetByIdAsync(id);

            return Ok(_mapper.Map<DiaryDTO>(diary));
        }

        /// <summary>
        /// Return mock diary that is used for testing and developing
        /// </summary>
        /// <returns>Mock diary to be used for testing and developin</returns>
        [Route("[action]", Name = "GetMockDiary")]
        [HttpGet]
        public List<DiaryEntryDTO> GetMock()
        {
            _logger.LogInformation("Someone called mock function to get diary");
            return new List<DiaryEntryDTO>
            {
                new DiaryEntryDTO
                {
                    Id = 1,
                    Book = new BookLiteDTO
                    {
                        BookId = 1,
                        Title = "Lord of the Rings: Two Towers",
                        AuthorId = 1,
                        AuthorName = "J.R.R. Tolkien"
                    },
                    StartDate = new DateOnly(2023,6,6),
                    EndDate = new DateOnly(2023,6,16),
                    Finished = true,
                    NumericalReview = 4,
                    Review = "Good fantasy. Interesting world. Nice characters."

                },
                new DiaryEntryDTO
                {
                    Id = 2,
                    Book = new BookLiteDTO
                    {
                        BookId = 2,
                        Title = "Kuolleet ja elävät",
                        AuthorId = 2,
                        AuthorName = "Hannu Mäkelä"
                    },
                    StartDate = new DateOnly(2023,5,1),
                    EndDate = new DateOnly(2023,5,12),
                    Finished = false,
                    NumericalReview = 3,
                    Review = "Mielenkiintoinen kirja. Hauskasti rakennettu. Tyly tarina"

                },
                new DiaryEntryDTO
                {
                    Id = 3,
                    Book = new BookLiteDTO
                    {
                        BookId = 3,
                        Title = "Story of his life",
                        AuthorId = 3,
                        AuthorName = "Other Dude"
                    },
                    StartDate = new DateOnly(2023,7,2),
                    EndDate = new DateOnly(2023,7,3),
                    Finished = true,
                    NumericalReview = 2,
                    Review = "Almost like story of my life!"
                }
            };
        }

        /// <summary>
        /// Adds diary entry
        /// </summary>
        /// <returns>Added diary entry</returns>
        [Route("[action]", Name = "AddOrUpdateDiaryEntry")]
        [HttpPost]
        public async Task<ActionResult<DiaryDTO>> AddOrUpdateDiaryEntry([FromBody] DiaryEntryDTO newEntry)
        {
            if (newEntry == null)
            {
                return BadRequest();
            }

            if (newEntry.Book != null)
            {
                if (newEntry?.Book?.AuthorId == 0 && newEntry?.Book?.AuthorName != null)
                {
                    var authorId = await _authorRepository.GetAuthorByNameAsync(newEntry.Book.AuthorName);

                    if (authorId == 0)
                    {
                        authorId = await _authorRepository.AddAuthorAsync(newEntry.Book.AuthorName);
                    }

                    newEntry.Book.AuthorId = authorId;
                }

                if (newEntry?.Book?.BookId == 0 && newEntry.Book.Title != null)
                {
                    var bookId = await _bookRepository.GetBookByTitleAsync(newEntry.Book.Title);

                    if (bookId == 0)
                    {
                        bookId = await _bookRepository.AddBookAsync(newEntry!.Book.Title!, newEntry.Book.AuthorId);
                    }

                    newEntry.Book.BookId = bookId;
                }
            }

            var diaryEntry = _mapper.Map<DiaryEntry>(newEntry);
            diaryEntry.DiaryId = 1;

            if (diaryEntry.Id == 0)
            {
                await _repository.AddDiaryEntryAsync(diaryEntry);
            }
            else
            {
                await _repository.UpdateDiaryEntryAsync(diaryEntry);
            }



            var updatedDiaryEntry = await _repository.GetDiaryEntryByIdAsync(diaryEntry.Id);
            
            return Ok(_mapper.Map<DiaryEntryDTO>(updatedDiaryEntry));
        }
    }
}