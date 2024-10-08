﻿using Moq;
using ToDo.Services;
using FluentAssertions;
using ToDo.Utility;
using ToDo.DTO;
using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ToDo.Controllers.Tests;

public class TaskItemsControllerTests : IDisposable
{
    private readonly Mock<ITaskItemService> _taskItemServiceMock = new();

    private TaskItemsController ObjectUnderTest => new(_taskItemServiceMock.Object);

    public void Dispose()
    {
        _taskItemServiceMock.Reset();
    }

    [Theory]
    [ClassData(typeof(GetTaskItemsAsyncTestAsyncData))]
    public async Task GetTaskItemsAsyncTestAsync(Result<IList<TaskItemDTO>> mockData, int expectResult)
    {
        _taskItemServiceMock.Setup(s => s.GetItemsAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockData);

        var controller = ObjectUnderTest;

        var actual = await controller.GetTaskItemsAsync() as IStatusCodeActionResult;

        actual.Should().NotBeNull();
        actual?.StatusCode.Should().Be(expectResult);
    }

    [Theory]
    [ClassData(typeof(GetTaskItemsAsyncTestAsyncData))]
    public async Task GetTaskItemAsyncTestAsync(Result<TaskItemDTO> mockData, int expectResult)
    {
        _taskItemServiceMock.Setup(s => s.GetItemAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockData);

        var controller = ObjectUnderTest;

        var actual = await controller.GetTaskItemAsync(0) as IStatusCodeActionResult;

        actual.Should().NotBeNull();
        actual?.StatusCode.Should().Be(expectResult);
    }

}



internal class GetTaskItemsAsyncTestAsyncData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [Result.Success(), StatusCodes.Status200OK];
        yield return [Result.NotFound(), StatusCodes.Status404NotFound];
        yield return [Result.Unviable(), StatusCodes.Status400BadRequest];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}