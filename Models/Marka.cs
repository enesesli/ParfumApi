namespace ParfumApi.Models;

public class Marka
{
    public int Id { get; set; }
    public string Ad { get; set; } = "";
    public string Ulke { get; set; } = "";

    public List<Parfum> Parfumler { get; set; } = new();
}
