using GameStore.Resources;
namespace GameStore.Models;

public class Game
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public List<Category>? Categories { get; set; }
}