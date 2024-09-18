using FluentAssertions;
using ToDo.Utility;
using ToDo.DTO;
using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ToDo.Controllers.Tests;

public class UserProfileControllerTests
{

    private UserProfileController ObjectUnderTest => new();

    [Theory]
    [ClassData(typeof(GetTaskBoardsAsyncTestAsyncData))]
    public async Task GetUserProfilessAsyncTestAsync(Result<IList<UserProfileDTO>> mockData, int expectResult)
    {
        var controller = ObjectUnderTest;

        var actual = await controller.GetUserProfiles() as IStatusCodeActionResult;

        actual.Should().NotBeNull();
        actual?.StatusCode.Should().Be(expectResult);
    }

    [Theory]
    [ClassData(typeof(GetTaskBoardsAsyncTestAsyncData))]
    public async Task GetUserProfileAsyncTestAsync(Result<UserProfileDTO> mockData, int expectResult)
    {
        var controller = ObjectUnderTest;

        var actual = await controller.GetUserProfile("username") as IStatusCodeActionResult;

        actual.Should().NotBeNull();
        actual?.StatusCode.Should().Be(expectResult);
    }

}



internal class GetUserProfilesAsyncTestAsyncData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [Result.Success(), StatusCodes.Status200OK];
        //yield return [Result.NotFound(), StatusCodes.Status404NotFound];
        //yield return [Result.Unviable(), StatusCodes.Status400BadRequest];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}