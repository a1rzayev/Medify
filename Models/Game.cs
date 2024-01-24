namespace GameStore.Models;

public class Game
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? Category { get; set; }
}