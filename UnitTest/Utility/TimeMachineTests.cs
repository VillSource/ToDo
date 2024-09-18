
using FluentAssertions;

namespace ToDo.Utility.Tests;

public class TimeMachineTests
{
    [Fact]
    public void NowTest()
    {
        var timeMachine = new TimeMachine();

        var actual = timeMachine.Now();

        actual.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
    }
}