using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureStore.Data.Models;

public class Image
{
	[Key] public int Id { get; set; }
	public string Name { get; set; }
	[NotMapped]
	public IFormFile File {get; set; }
}
