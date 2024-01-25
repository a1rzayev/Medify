namespace GameStore.Models;

public class Game
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? Category { get; set; }
    // public Game(int id, string? name, double price, string? category)
    // {
    //     this.Id = id;
    //     this.Name = name;
    //     this.Price = price;
    //     this.Category = category;
    // }
}