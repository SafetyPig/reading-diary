using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDiary.DB.Models
{
    public class Author
    {
        /// <summary>
        /// ID of the author
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the author
        /// </summary>
        [MaxLength(512)]
        public required string Name { get; set; }

        /// <summary>
        /// Books written by the author
        /// </summary>
        public ICollection<Book>? Books { get; set; }
    }
}
