using System;
namespace StringCalculatorKata
{
	public class StringCalculatorSolution
	{
		private List<char> delimiters = new() { ',', '\n' };

		public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            numbers = ExtractCustomDelimiter(numbers);

            var parsedNumbers = SplitNumbers(numbers)
                                .Select(int.Parse);

            if (parsedNumbers.Any(i => i < 0))
            {
                throw new Exception("negatives are not allowed");
            }

            return parsedNumbers.Sum();
              
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

