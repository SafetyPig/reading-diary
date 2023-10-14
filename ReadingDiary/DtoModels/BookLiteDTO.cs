namespace ReadingDiary.APImodels
{
    public class BookLiteDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int BookId { get; set; } 

        /// <summary>
        /// Title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Author of the book
        /// </summary>
        public string? AuthorName { get; set; }
    }
}
