using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Domain.Entities;

namespace Library.Application.DTOs
{
    // DTO for creating a new book
    public class BookCreateDto
    {
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

    // DTO for reading/fetching book data
    public class BookReadDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public int? PublisherId { get; set; }
        public DateTime? PublishDate { get; set; }
        public string ISBN { get; set; }
        public decimal? Price { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreateDate { get; set; }

        // Optionally: if you want to return related names
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
    }

}