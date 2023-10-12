using System;
namespace StringCalculatorKata
{
	public class StringCalculatorSolution
	{
		private List<char> delimiters = new() { ',', '\n' };

		public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            IEnumerable<int> parsedNumbers = ParseNumbers(numbers);
            ThrowErrorIfNegativeNumbersAreFound(parsedNumbers);
            return parsedNumbers.Sum();

        }

        private IEnumerable<int> ParseNumbers(string numbers)
        {
            numbers = ExtractCustomDelimiter(numbers);

            var parsedNumbers = SplitNumbers(numbers)
                                .Select(int.Parse);
            return parsedNumbers;
        }

        private static void ThrowErrorIfNegativeNumbersAreFound(IEnumerable<int> parsedNumbers)
        {
            var negatives = parsedNumbers.Where(i => i < 0);
            if (negatives.Any())
            {
                throw new Exception("negatives are not allowed: " + string.Join(",", negatives));
            }
        }

        private string ExtractCustomDelimiter(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                delimiters.Add(numbers[2]);
                numbers = numbers.Substring(4);
            }

            return numbers;
        }

        private string[] SplitNumbers(string numbers)
		{
			return numbers.Split(delimiters.ToArray());
		}
    }
}

