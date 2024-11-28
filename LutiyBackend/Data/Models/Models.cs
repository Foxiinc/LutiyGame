public class Users
{
    public int Id { get; set; }
    public int UserId {get; set;}
    public int CountServers {get; set;}
    public ICollection<Servers>? Servers { get; set; } // Marked as nullable
    public string? Name { get; set; }
    public int CountBytesAll { get; set; }
    public int CountRefs {get; set;}
    public int CountBoosts {get; set;}
    public bool Refferal {get; set;}
}

public class Servers
{
    public Servers()
    {
        ServerName = GenerateServerName();
    }

    private string GenerateServerName()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 16)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public int Id { get; set; }
    public string ServerName { get; set; }
    public int CountBytes { get; set; }
    public int UserId { get; set; }
    public Users Users { get; set; }
}
