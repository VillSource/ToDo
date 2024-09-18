using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;
using ToDo.Repositories;
using ToDo.Models;
using ToDo.Utility;

namespace ToDo.Services.Tests;

public class TaskItemServiceTests : IDisposable
{
    // Mock object
    private readonly Mock<TaskItemReadRepository> _itemRepoMock = new();
    private readonly Mock<TimeMachine> _timeMachineMock = new();

    // Mock data
    private readonly DateTime FreezedAt = new DateTime(2000,2,2);

    // Object Under Test
    private TaskItemService ObjectUnderTest => new(_itemRepoMock.Object, _timeMachineMock.Object);

    // Setup
    // public TaskItemReadRepositoryTests()
    // {
        // _timeMachineMock.Setup(time => time.Now())
        //     .Return(FreezedAt);
    // }

    // Teardown
    public void Dispose()
    {
        _itemRepoMock.Reset();
        _timeMachineMock.Reset();
    }


    [Theory]
    [InlineData(0, false, ResultStatus.NotFound)]
    [InlineData(1, true, ResultStatus.Success)]
    public async Task GetItemAsyncTest(int id, bool expectSuccess, ResultStatus expectedStatus)
    {
        var service = ObjectUnderTest;
        _itemRepoMock.Setup(repo=>repo.GetByIdAsync(It.Is(1), It.IsAny<CancellationToken>()))
            .Return(new TaskItemEntity(){Id = 1});

        var actual = await service.GetItemAsync(id);

        actual.IsSuccess.Should().Be(expectSuccess);
        actual.Status.Should().Be(expectedStatus);
    }
}
