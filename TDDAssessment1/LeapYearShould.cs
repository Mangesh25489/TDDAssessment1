using FluentAssertions;

namespace TDDAssessment1
{
    public class LeapYearShould
    {
        [Theory]
        [InlineData(2001, false)]
        [InlineData(1900, false)]
        [InlineData(1800, false)]
        public void Return_False(int year, bool expectedOutput)
        {
            bool isLeapYear = LeapYear.IsLeapYear(year);
            isLeapYear.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData(2000, true)]
        [InlineData(1996, true)]
        [InlineData(1840, true)]
        public void Return_True(int year, bool expectedOutput)
        {
            bool isLeapYear = LeapYear.IsLeapYear(year);
            isLeapYear.Should().Be(expectedOutput);
        }
    }

    public class LeapYear
    {
        internal static bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                    return (year % 400 == 0);
                return true;
            }
            return false;
        }
    }
}