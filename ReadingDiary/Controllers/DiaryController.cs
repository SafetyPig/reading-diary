using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using ReadingDiary.APImodels;

namespace ReadingDiary.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class DiaryController : ControllerBase
    {

        private readonly ILogger<DiaryController> _logger;

        public DiaryController(ILogger<DiaryController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Returns asked Diary
        /// </summary>
        /// <returns>Asked diary</returns>
        [HttpGet(Name = "GetDiary")]
        public IEnumerable<Diary> Get()
        {
            return new List<Diary>();
        }

        /// <summary>
        /// Return mock diary that is used for testing and developing
        /// </summary>
        /// <returns>Mock diary to be used for testing and developin</returns>
        [Route("[action]", Name = "GetMockDiary")]
        [HttpGet]
        public List<DiaryEntry> GetMock()
        {
            _logger.LogInformation("Someone called mock function to get diary");
            return new List<DiaryEntry>
            {
                new DiaryEntry
                {
                    Id = 1,
                    Book = new BookLite
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
                new DiaryEntry
                {
                    Id = 2,
                    Book = new BookLite
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
                new DiaryEntry
                {
                    Id = 3,
                    Book = new BookLite
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