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

