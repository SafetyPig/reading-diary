using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDiary.DB.Models
{
    public class Book
    {
        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Author ID FK
        /// </summary>
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        /// <summary>
        /// Title of the book
        /// </summary>
        [MaxLength(1024)]
        public string? Title { get; set; }

        /// <summary>
        /// In which entries the book is in
        /// </summary>
        public ICollection<DiaryEntry>? DiaryEntries { get; set; }
    }
}
