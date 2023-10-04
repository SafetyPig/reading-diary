using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDiary.DB.Models
{    
    public class DiaryEntry
    {
        /// <summary>
        /// ID of the entry
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreing key for the book
        /// </summary>
        [ForeignKey("Book")]
        public int BookId { get; set; }

        /// <summary>
        /// Author of the book
        /// </summary>
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        /// <summary>
        /// When reading started
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// When reading ended
        /// </summary>
        public DateTime EndDate { get; set; }

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
