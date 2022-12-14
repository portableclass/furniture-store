using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace FurnitureStore.Data.Models;

public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Field 'Name' is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Field 'Description' is required.")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Field 'Price' is required.")]
    public uint Price { get; set; }
    [Required(ErrorMessage = "Field 'Storage' is required.")]
    public int StorageId { get; set; }
    public virtual Storage? Storage { get; set; }
    public int ImageId { get; set; }
    public virtual Image? Image { get; set; }
}
