namespace FurnitureStore.Data.Models;

public class Worker
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Surname { get; set; }
    public string Image { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string Position { get; set; }
}
