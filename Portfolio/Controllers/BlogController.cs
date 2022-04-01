using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess;
using Portfolio.Entity;
using Portfolio.ViewModels;

namespace Portfolio.Controllers;

public class BlogController : Controller
{
    private Context _context { get; set; }
    public BlogController(Context context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        return View(_context.Posts);
    }

    [HttpGet]
    public IActionResult AddBlog()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddBlog([FromForm]AddBlogViewModel blogViewModel)
    {
        var tagContent = blogViewModel.Tags.Split(' ');
        var tagsContent = _context.Tags.Where(tag => tagContent.Contains(tag.Content)).ToList();
        var newTags = (from tagName in tagContent
                where tagsContent.All(tag => tag.Content != tagName)
                select new Tag() {Content = tagName}
            ).ToList();
        
        _context.Tags.AddRange(newTags);
        _context.SaveChanges();
        tagsContent = _context.Tags.Where(tag => tagContent.Contains(tag.Content)).ToList();

        var post = new Post()
        {
            Title = blogViewModel.Title,
            Content = blogViewModel.Content,
            Tags = tagsContent
        };

        
        _context.Posts.Add(post);
        _context.SaveChanges();

        return Ok();
    }
}