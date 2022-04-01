namespace Portfolio.Entity;

public class Tag
{
    public Guid Id { get; set; }
    
    public string Content { get; set; }
    
    public List<Post> Posts { get; set; } = null!;
}