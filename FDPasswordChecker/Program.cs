using FluentAssertions;
using Xunit;

public class Program
{
    [Theory]
    [InlineData("asdfAsdf")]
    void should_be_safe(string input)
    {
        var checkCaps = CheckCaps(input);

        checkCaps.Should().Be(true);
    }

    private Func<string, bool> CheckCaps => x => x.Any(char.IsUpper);
}