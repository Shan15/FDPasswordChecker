using FluentAssertions;
using Xunit;

public class Program
{
    [Theory]
    [InlineData("apple", false)]
    [InlineData("Banan123", false)]
    [InlineData("hlaksdfjLKJALKSDF-1234", true)]
    void should_be_safe(string password, bool isSafe)
    {
        var checker = And(CheckUpper, CheckLower, CheckNumber, CheckSpecialCase, HasEnoughChars);

        checker(password).Should().Be(isSafe);
    }

    private static Func<string, bool> CheckUpper => x => x.Any(char.IsUpper);
    private static Func<string, bool> CheckLower => x => x.Any(char.IsLower);
    private static Func<string, bool> CheckNumber => x => x.Any(char.IsDigit);
    private static Func<string, bool> CheckSpecialCase => x => x.Any(c => !char.IsLetterOrDigit(c));
    private static Func<string, bool> HasEnoughChars => x => x.Length >= 8;

    static Func<T, bool> And<T>(params Func<T, bool>[] checkers) =>
        x => checkers.All(checker => checker(x));

}