using Microsoft.AspNetCore.Identity;

namespace Portfolio.Entity;


public class ApplicationUser : IdentityUser
{
    public int Year { get; set; }
}