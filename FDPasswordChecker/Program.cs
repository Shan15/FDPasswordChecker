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
        var checkSpecialCase = CheckSpecialCase(input);
        var checkNumber = CheckNumber(input);

        checkUpper.Should().Be(true);
        checkNumber.Should().Be(true);
        checkLower.Should().Be(true);
        checkSpecialCase.Should().Be(true);
    }

    private static Func<string, bool> CheckUpper => x => x.Any(char.IsUpper);
    private static Func<string, bool> CheckLower => x => x.Any(char.IsLower);
    private static Func<string, bool> CheckNumber => x => x.Any(char.IsDigit);
    private static Func<string, bool> CheckSpecialCase => x => x.Any(c => !char.IsLetterOrDigit(c));
}