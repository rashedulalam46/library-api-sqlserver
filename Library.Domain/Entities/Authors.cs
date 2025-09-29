
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Library.Domain.Entities;

public class Authors
{
    [Key]
    public int author_id { get; set; }

    [Display(Name = "Author Name", Prompt = "Enter author name")]
    [Required(ErrorMessage = "Author name is required.")]
    [StringLength(100)]
    public string author_name { get; set; }

    [StringLength(2)]
    public string country { get; set; }

    [StringLength(500)]
    public string address { get; set; }

    [StringLength(20)]
    public string phone { get; set; }

    [StringLength(200)]
    [EmailAddress]
    public string email { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime? create_date { get; set; }

    [Required(ErrorMessage = "Active status is required.")]
    [DefaultValue(true)]
    public bool active { get; set; }
}
