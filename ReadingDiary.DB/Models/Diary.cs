using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDiary.DB.Models
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
