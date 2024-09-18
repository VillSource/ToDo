using Xunit;
using ToDo.Services;
using FluentAssertions;
using Moq;
using ToDo.Repositories;
using ToDo.Models;
using ToDo.Utility;
using ToDo.DTO;
using System.Collections;

namespace ToDo.Services.Tests;

public class TaskItemServiceTests : IDisposable
{
    // Mock object
    private readonly Mock<TaskItemReadRepositoryBase> _itemRepoMock = new();
    private readonly Mock<TimeMachine> _timeMachineMock = new();

    // Object Under Test
    private TaskItemService ObjectUnderTest => new(_itemRepoMock.Object, _timeMachineMock.Object);

    // Teardown
    public void Dispose()
    {
        _itemRepoMock.Reset();
        _timeMachineMock.Reset();
    }


    [Theory]
    [InlineData(0, ResultStatus.NotFound, null)]
    [InlineData(1, ResultStatus.Success, 1)]
    public async Task GetItemAsyncTest(int id, ResultStatus expectedStatus, int? expectedId)
    {
        _itemRepoMock.Setup(repo => repo.GetByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new TaskItemEntity() { Id = 1 });

        var service = ObjectUnderTest;

        var actual = await service.GetItemAsync(id);

        actual.Status.Should().Be(expectedStatus);
        actual.Value?.Id.Should().Be(expectedId);
    }

    [Theory]
    [ClassData(typeof(GetItemsAsyncTestData))]
    public async Task GetItemsAsyncTest(IList<TaskItemEntity> mockResultRepo, ResultStatus expectStatus)
    {
        _itemRepoMock.Setup(repo => repo.ListAsync(It.IsAny<int?>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockResultRepo);

        var service = ObjectUnderTest;

        var actual = await service.GetItemsAsync(CancellationToken.None);

        actual!.Status.Should().Be(expectStatus);
    }
}


#region Test Data Class
internal class GetItemsAsyncTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return
        [
            new List<TaskItemEntity>(){new () { Id = 1 }, new () { Id = 2 }, new () { Id = 3 } },
            ResultStatus.Success,
        ];

        yield return
        [
            new List<TaskItemEntity>(){ },
            ResultStatus.NotFound,
        ];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
#endregion
