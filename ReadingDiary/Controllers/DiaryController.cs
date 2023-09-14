using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using ReadingDiary.APImodels;

namespace ReadingDiary.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
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
        [HttpGet    ]
        public Diary GetMock()
        {
            _logger.LogInformation("Someone called mock function to get diary");
            return new Diary()
            {
                Id = 1,
                DiaryEntries = new List<DiaryEntry>
                {
                    new DiaryEntry
                    {   
                        Book = new BookLite
                        {
                            BookId = 1,
                            Name = "Book of the dead"
                        },
                        StartDate = new DateTime(2023,6,6),
                        EndDate = new DateTime(2023,6,16),
                        Finished = true,
                        NumericalReview = 3,
                        Review = "Joyful book, but no very well written"
                        
                    },
                    new DiaryEntry
                    {
                        Book = new BookLite
                        {
                            BookId = 2,
                            Name = "Ring of the lords"
                        },
                        StartDate = new DateTime(2023,5,1),
                        EndDate = new DateTime(2023,5,12),
                        Finished = false,
                        NumericalReview = 1,
                        Review = "Hockey book, meeh"

                    },
                    new DiaryEntry
                    {
                        Book = new BookLite
                        {
                            BookId = 3,
                            Name = "Story of his life"
                        },
                        StartDate = new DateTime(2023,7,2),
                        EndDate = new DateTime(2023,7,3),
                        Finished = true,
                        NumericalReview = 5,
                        Review = "Almost like story of my life!"
                    }
                }
            };
        }
    }
}