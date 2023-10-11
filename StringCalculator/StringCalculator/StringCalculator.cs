namespace StringCalculatorKata;

public class StringCalculator
{
    public int Add(string number)
    {
        int sum = 0;
        char[] deliminiters = { ',', '\n' };
        string[] n = number.Split(deliminiters);
        Console.Write(deliminiters);

        if (string.IsNullOrWhiteSpace(number))
        {
            return 0;
        }

        if (number.Length < 2)
        {
            foreach (var c in n)
            {
                sum += Convert.ToInt32(c);
            }

            return sum;
        }

        string first2CharactersOfString = number.Substring(0, 2);
        Console.Write(first2CharactersOfString);
        if (first2CharactersOfString == "//")
        {
            deliminiters = deliminiters.Concat(new char[] { number[2] }).ToArray();
            Console.Write(deliminiters);
        }

        n = number.Split(deliminiters);

        foreach (var c in n)
        {
            sum += Convert.ToInt32(c);  
        }

        return sum;
    }

}

