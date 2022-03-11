namespace Portfolio.Entity;

public class Request
{
    public Guid RequestId { get; set; }
    public string Name { get; set; }
    public string EMail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}