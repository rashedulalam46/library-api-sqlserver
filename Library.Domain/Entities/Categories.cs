using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class Categories
{
	[Key]
	public int category_id { get; set; }
	public string category_name { get; set; }
	public bool active { get; set; }
}