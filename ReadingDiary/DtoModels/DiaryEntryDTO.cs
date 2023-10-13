namespace ReadingDiary.APImodels
{
    public class DiaryEntryDTO
    {
        /// <summary>
        /// ID of the entry
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the book
        /// </summary>
        public BookLiteDTO? Book {  get; set; }

        /// <summary>
        /// When reading started
        /// </summary>
        public DateOnly StartDate { get; set; }   

        /// <summary>
        /// When reading end
        /// </summary>
        public DateOnly EndDate { get; set;}

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
