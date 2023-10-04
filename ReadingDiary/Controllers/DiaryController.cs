using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using ReadingDiary.APImodels;
using ReadingDiary.DB.Repositories;
using ReadingDiary.DB.RepositoryInterfaces;

namespace ReadingDiary.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class DiaryController : ControllerBase
    {

        private readonly ILogger<DiaryController> _logger;
        private readonly IDiaryRepository _repository;

        public DiaryController(ILogger<DiaryController> logger, IDiaryRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Returns asked Diary
        /// </summary>
        /// <returns>Asked diary</returns>
        [HttpGet(Name = "GetDiary")]
        public async Task<ActionResult<DiaryDTO>> Get(int id)
        {
            var diary = await _repository.GetByIdAsync(id);
            return Ok(diary);
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
                        Name = "Lord of the Rings: Two Towers"
                    },
                    Author = "J.R.R. Tolkien",
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
                        Name = "Kuolleet ja elävät"
                    },
                    Author = "Hannu Mäkelä",
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
                        Name = "Story of his life"
                    },
                    Author = "Other Dude",
                    StartDate = new DateOnly(2023,7,2),
                    EndDate = new DateOnly(2023,7,3),
                    Finished = true,
                    NumericalReview = 2,
                    Review = "Almost like story of my life!"
                }
            };
        }
    }
}