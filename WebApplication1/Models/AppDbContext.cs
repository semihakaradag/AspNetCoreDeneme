using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
       

    }

}
