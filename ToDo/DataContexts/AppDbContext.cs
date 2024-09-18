using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.DataContexts;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
    public AppDbContext() { }
    public virtual DbSet<TaskItemEntity> TaskItems { get; set; }
    public virtual DbSet<TaskBoardEntity> TaskBoards { get; set; }
    public virtual DbSet<UserProfileEntity> UserProfiles { get; set; }
}
