using FluentAssertions;
using Xunit;

public class Program
{
    [Theory]
    [InlineData("asdfAsdf-123")]
    void should_be_safe(string input)
    {
        var checkUpper = CheckUpper(input);
        var checkLower = CheckLower(input);

        checkUpper.Should().Be(true);
        checkLower.Should().Be(true);
    }

    private static Func<string, bool> CheckUpper => x => x.Any(char.IsUpper);
    private static Func<string, bool> CheckLower => x => x.Any(char.IsLower);
}