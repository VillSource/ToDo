using ToDo.Models;

namespace ToDo.DataContexts;

public class AppDbContextSeedDataTest(IServiceProvider _serviceProvider) : IHostedService
{
    private AppDbContext context;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();

        context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await context.Database.EnsureCreatedAsync(cancellationToken);

        await SeedTaskUserProfile();
        await SeedTaskBoard();
        await SeedTaskItem();
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    private async Task SeedTaskUserProfile()
    {
        context.Add(new UserProfileEntity()
        {
            CreatedAt = DateTime.Now,
            DisplayName = "Test User Display Name",
            Username = "TEST_USER",
            Id = 1,
            LastUpdated = DateTime.Now,
        });
        await context.SaveChangesAsync();
    }
    private async Task SeedTaskBoard()
    {
        context.Add(new TaskBoardEntity()
        {
            Id = 1,
            CreatedAt = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            CreatedBy = 1,
            LastUpdatedBy = 1,
            Name = "Test Board",
            Status = Constants.TaskBoardStatus.Open,
        });
        await context.SaveChangesAsync();
    }
    private async Task SeedTaskItem()
    {
        context.Add(new TaskItemEntity()
        {
            Id = 1,
            CreatedAt = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            Description = "Do Test",
            Title = "First Task",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow + TimeSpan.FromDays(1),
            Status = Constants.TaskItemStatus.Todo,
            TaskBoardId = 1,
        });

        context.Add(new TaskItemEntity()
        {
            Id = 2,
            CreatedAt = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            Description = "Do Test...",
            Title = "Draft Task",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow + TimeSpan.FromMinutes(5),
            Status = Constants.TaskItemStatus.Draft,
            TaskBoardId = 1,
        });
        await context.SaveChangesAsync();
    }
}
