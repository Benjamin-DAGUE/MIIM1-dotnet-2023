#nullable disable warnings

namespace UnicornManager.DBLib;

public class Unicorn
{
    public int Identifier { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
}
