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


    [Fact]
    public async Task GetByIdAsyncTest()
    {
        int id = 1;
        var repo = ObjectUnderTest;
        string expectedTitle = "one";

        var actual = await repo.GetByIdAsync(id, CancellationToken.None);

        actual.Should().NotBeNull();
        actual!.Title.Should().Be(expectedTitle);
    }

    [Fact]
    public async Task GetByIdAsync_Invalid_Test()
    {
        int id = 11;
        var repo = ObjectUnderTest;

        var actual = await repo.GetByIdAsync(id, CancellationToken.None);

        actual.Should().BeNull();
    }

    [Theory]
    [InlineData(null, 5)]
    [InlineData(2, 2)]
    [InlineData(100, 5)]
    public async Task ListAsyncTest(int? take, int expectedElement){
        var repo = ObjectUnderTest;

        var actual = await repo.ListAsync(take);

        actual.Count.Should().Be(expectedElement);
    }

}
