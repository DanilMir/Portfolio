using Microsoft.AspNetCore.Mvc;
using Portfolio.Misc.Services.EmailSender;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class Contacts : Controller
{
    private IEmailService _emailService;

    public Contacts(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Get()
    {
        var message = new Message(new string[] { "mirgayazov02@gmail.com" }, "Amogus", "Если ты это читаешь то ты LOX");
        _emailService.SendEmail(message);
        return Ok();
    }

    [HttpPost]
    public IActionResult SendMessage([FromForm]ContactModel contact)
    {
        Console.WriteLine(contact.Message);
        var message = new Message(new string[] { "mirgayazov02@gmail.com" }, contact.Subject, $"{contact.EMail}\n{contact.Name}\n{contact.Message}");
        _emailService.SendEmail(message);
        return Ok();
    }
}