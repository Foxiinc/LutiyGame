public class Server{
    public int Id {get; set;}
    public string Name {get; set;} = "";
    public int CountBytes {get; set;}
    public int CountSphere {get; set;}
    public int UserId { get; set; } // Внешний ключ
    public User? User { get; set; } // Навигационное свойство

}
