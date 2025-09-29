using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Domain.Entities;
using Library.Domain.Enums;
namespace Library.Application.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public int? PublisherId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? PublishDate { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Range(0, 9999.99)]
        public decimal? Price { get; set; }

        public bool? Active { get; set; }
    }
}