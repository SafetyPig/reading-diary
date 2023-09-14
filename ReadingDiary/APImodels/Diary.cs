namespace ReadingDiary.APImodels
{
    public class Diary
    {
        /// <summary>
        /// The Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Entries in the diary
        /// </summary>
        public List<DiaryEntry>? DiaryEntries { get; set; }

    }
}
