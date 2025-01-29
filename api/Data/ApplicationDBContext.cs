namespace api.Data;

using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {

    }

    public DbSet<Models.Stock> Stocks { get; set; } = null!;

    public DbSet<Models.Comment> Comments { get; set; } = null!;
}
