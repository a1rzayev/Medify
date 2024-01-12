namespace GameStore.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public List<Game>? Games { get; set; }
    public bool IsAdmin { get; set; }  
}