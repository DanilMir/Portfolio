namespace Portfolio.Entity;

public class Post
{
    public Guid Id { get; set; }
    public List<Tag> Tags { get; set; }
    public string Content { get; set; }
}