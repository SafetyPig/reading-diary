namespace ReadingDiary.APImodels
{
    public class DiaryEntry
    {
        /// <summary>
        /// Name of the book
        /// </summary>
        public BookLite? Book {  get; set; }

        /// <summary>
        /// When reading started
        /// </summary>
        public DateTime? StartDate { get; set; }   

        /// <summary>
        /// When reading end
        /// </summary>
        public DateTime? EndDate { get; set;}

        /// <summary>
        /// Written revies
        /// </summary>
        public string? Review { get; set; }

        /// <summary>
        /// Numerical review between 1-5.
        /// </summary>
        public int NumericalReview { get; set; }

        /// <summary>
        /// Did the reading finish the book
        /// </summary>
        public bool Finished { get; set; }

    }
}
