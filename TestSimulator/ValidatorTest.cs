using Simulator;

namespace TestSimulator;

public class ValidatorTest
{
    [Theory]
    [InlineData(3, 5, 10, 5)]
    [InlineData(15, 5, 10, 10)]
    [InlineData(7, 5, 10, 7)]
    public void Limiter_ShouldReturnExpectedValue(int value, int min, int max, int expected)
    {
        var result = Validator.LimiterEO(value, min, max);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("   Shrek    ", 3, 10, '#', "Shrek")]
    [InlineData("   ", 3, 10, '#', "###")]
    [InlineData("  donkey   ", 3, 10, '#', "Donkey")]
    [InlineData("Puss in Boots", 3, 10, '#', "Puss in Bo")]
    [InlineData("a                           troll name", 3, 10, '#', "A##")]
    [InlineData("     Cats    ", 3, 10, '#', "Cats")]
    [InlineData("Mice              are great", 3, 10, '#', "Mice")]

    public void ShortenerCA_ShouldReturnExpectedValue(string value, int min, int max, char placeholder, string expected)
    {
        var name = Validator.ShortnerCA(value, min, max, placeholder);

        Assert.Equal(expected, name);
    }

}
