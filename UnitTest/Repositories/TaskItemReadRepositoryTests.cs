using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;
using ToDo.DataContexts;
using ToDo.Models;

namespace ToDo.Repositories.Tests;

public class TaskItemReadRepositoryTests : IDisposable
{
    // Mock object
    private readonly Mock<AppDbContext> _dbContextMock = new();

    // Mock data
    private readonly List<TaskItemEntity> _dataMockTaskItems =
    [
        new () {Id = 0, Title = "zero"},
        new () {Id = 1, Title = "one"},
        new () {Id = 2, Title = "two"},
        new () {Id = 3, Title = "three"},
        new () {Id = 4, Title = "four"},
    ];

    // Object Under Test
    private TaskItemReadRepository ObjectUnderTest => new(_dbContextMock.Object);

    // Setup
    public TaskItemReadRepositoryTests()
    {
        _dbContextMock.Setup(context => context.TaskItems)
            .ReturnsDbSet(_dataMockTaskItems);
    }

    // Teardown
    public void Dispose()
    {
        _dbContextMock.Reset();
    }


    [Theory]
    [InlineData(1, "one")]
    public async Task GetByIdAsyncTest(int id, string expectedTitle)
    {
        var repo = ObjectUnderTest;

        var actual = await repo.GetByIdAsync(id, CancellationToken.None);

        actual.Should().NotBeNull();
        actual!.Title.Should().Be(expectedTitle);
    }
}
