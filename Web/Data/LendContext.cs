using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Web.Models;

namespace Web.Data;

public class LendContext : IdentityDbContext<User>
{
    public LendContext(DbContextOptions<LendContext> options) : base(options) { }
}
