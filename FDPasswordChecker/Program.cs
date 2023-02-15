using FluentAssertions;
using Xunit;

public class Program
{
    static List<string> GetFilteredPassword(Func<string, bool> filter)
    {
        var list = new List<string> { "apple", "Banan123", "hlaksdfjLKJALKSDF-1234" };

        return list.Where(filter).ToList();
    }

    [Theory]
    [InlineData(1)]
    void should_be_safe(int count)
    {
        var checkUpper = CheckUpper();
        var checkLower = CheckLower();
        var checkSpecialCase = CheckSpecialCase();
        var checkNumber = CheckNumber();

        var checker = And(checkUpper, checkLower, checkSpecialCase, checkNumber);
        var actual = GetFilteredPassword(checker);
        
        actual.Count.Should().Be(count);
    }

    private static Func<string, bool> CheckUpper() => x => x.Any(char.IsUpper);
    private static Func<string, bool> CheckLower() => x => x.Any(char.IsLower);
    private static Func<string, bool> CheckNumber() => x => x.Any(char.IsDigit);
    private static Func<string, bool> CheckSpecialCase() => x => x.Any(c => !char.IsLetterOrDigit(c));

    static Func<T, bool> And<T>(params Func<T, bool>[] checkers) =>
        x => checkers.All(checker => checker(x));
}