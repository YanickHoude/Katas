using System;
namespace StringCalculatorKata
{
	public class StringCalculatorSolution
	{
		private List<string> delimiters = new() { "," , "\n" };

		public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            IEnumerable<int> parsedNumbers = ParseNumbers(numbers);
            ThrowErrorIfNegativeNumbersAreFound(parsedNumbers);
            return parsedNumbers.Where(x=> x<1001).Sum();

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
                var slashToNewLine = numbers.Substring(2, numbers.IndexOf('\n') - 2);

                if (slashToNewLine.Length > 1)
                {
                    var insideBrackets = slashToNewLine.Substring(1, slashToNewLine.Length - 2);
                    var delimArray = insideBrackets.Split("][", StringSplitOptions.None);

                    delimiters.AddRange(delimArray);
                }
                else
                {
                    delimiters.Add(slashToNewLine);
                }
                
                numbers = numbers.Substring(slashToNewLine.Length + 3);
            }

            return numbers;
        }

        private string[] SplitNumbers(string numbers)
        {
			return numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
		}
    }
}

