using FluentAssertions;

namespace TDDAssessment1
{
    public class FibonacciShould
    {
        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        public void ThrowsException_IfPositionIsNegativeOrZero(int position)
        {
            Assert.Throws<Exception>(() => Fibonacci.GenerateFibonacciNumbers(position));
        }

        [Theory]
        [InlineData(1, "0")]
        [InlineData(2, "0, 1")]
        [InlineData(3, "0, 1, 1")]
        [InlineData(5, "0, 1, 1, 2, 3")]
        [InlineData(10, "0, 1, 1, 2, 3, 5, 8, 13, 21, 34")]
        [InlineData(12, "0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89")]
        public void Return_FibonacciNumbers_PositivePosition(int position, string expectedOutput)
        {
            var fibonacciNumbers = Fibonacci.GenerateFibonacciNumbers(position);
            fibonacciNumbers.Should().Be(expectedOutput);
        }
    }

    public class Fibonacci
    {
        internal static string GenerateFibonacciNumbers(int position)
        {
            if (position <= 0) throw new Exception("Only positive and non zero position is allowed");

            List<int> fibonacciNumbers = new List<int>();

            if (1 <= position) fibonacciNumbers.Add(0);
            if (2 <= position) fibonacciNumbers.Add(1);

            for (int i = 2; i < position; i++)
            {
                fibonacciNumbers.Add(fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2]);
            }

            return string.Join(", ", fibonacciNumbers);
        }
    }
}
