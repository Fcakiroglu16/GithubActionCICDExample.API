using Microsoft.EntityFrameworkCore;

namespace GithubActionCICDExample.API;

public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos => Set<Todo>();
}
