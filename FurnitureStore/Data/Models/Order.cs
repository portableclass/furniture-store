namespace FurnitureStore.Data.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public List<Product> Products { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public int WorkerId { get; set; }
    public virtual Worker Worker { get; set; }
}
