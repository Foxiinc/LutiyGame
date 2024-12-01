public class User
{
    public int Id { get; set; }
    public int UserId { get; set; } 
    public string Name { get; set; } = "";
    public int AllBytes {get; set;}
    public int CountServers {get; set;}
    public ICollection<Server> Servers { get; set; } = new List<Server>();

    public int[] Boosts { get; set; } = Array.Empty<int>();
    public int CountRefs{get; set;}
    public bool Refferal{get; set;}
}



