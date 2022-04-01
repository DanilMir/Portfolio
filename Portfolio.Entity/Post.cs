using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entity;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public List<Tag> Tags { get; set; } = null!;
    public string Content { get; set; } = null!;
}