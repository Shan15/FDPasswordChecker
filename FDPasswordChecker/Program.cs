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

        var checker = And<string>(checkUpper, checkLower, checkSpecialCase, checkNumber);
        
        checker.Should().Be(true);
    }

    private static Func<string, bool> CheckUpper => x => x.Any(char.IsUpper);
    private static Func<string, bool> CheckLower => x => x.Any(char.IsLower);
    private static Func<string, bool> CheckNumber => x => x.Any(char.IsDigit);
    private static Func<string, bool> CheckSpecialCase => x => x.Any(c => !char.IsLetterOrDigit(c));
    static Func<T, bool> And<T>(params Func<T, bool>[] checkers) =>
        x => checkers.All(checker => checker(x));
}