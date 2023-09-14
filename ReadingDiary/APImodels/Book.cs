namespace ReadingDiary.APImodels
{
    public class Book
    {
        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the book
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The name of the author
        /// </summary>
        public string? AuthorName {  get; set; }
    }
}
