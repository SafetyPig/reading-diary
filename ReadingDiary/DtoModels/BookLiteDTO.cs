namespace ReadingDiary.APImodels
{
    public class BookLiteDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int BookId { get; set; } 

        /// <summary>
        /// Name
        /// </summary>
        public string? Name { get; set; }

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
