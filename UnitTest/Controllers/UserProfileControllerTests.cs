using FluentAssertions;
using ToDo.Utility;
using ToDo.DTO;
using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ToDo.Controllers.Tests;

public class TaskBoardsControllerTests
{

    private TaskBoardsController ObjectUnderTest => new();

    [Theory]
    [ClassData(typeof(GetTaskBoardsAsyncTestAsyncData))]
    public async Task GetTaskBoardsAsyncTestAsync(Result<IList<TaskBoardDTO>> mockData, int expectResult)
    {
        var controller = ObjectUnderTest;

        var actual = await controller.GetTaskBoards() as IStatusCodeActionResult;

        actual.Should().NotBeNull();
        actual?.StatusCode.Should().Be(expectResult);
    }

    [Theory]
    [ClassData(typeof(GetTaskBoardsAsyncTestAsyncData))]
    public async Task GetTaskBoardAsyncTestAsync(Result<TaskBoardDTO> mockData, int expectResult)
    {
        var controller = ObjectUnderTest;

        var actual = await controller.GetTaskBoard(0) as IStatusCodeActionResult;

        actual.Should().NotBeNull();
        actual?.StatusCode.Should().Be(expectResult);
    }

}



internal class GetTaskBoardsAsyncTestAsyncData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [Result.Success(), StatusCodes.Status200OK];
        //yield return [Result.NotFound(), StatusCodes.Status404NotFound];
        //yield return [Result.Unviable(), StatusCodes.Status400BadRequest];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}