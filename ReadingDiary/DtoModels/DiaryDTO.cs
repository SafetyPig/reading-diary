namespace ReadingDiary.APImodels
{
    public class DiaryDTO
    {
        /// <summary>
        /// The Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Entries in the diary
        /// </summary>
        public List<DiaryEntryDTO>? DiaryEntries { get; set; }

    }
}
