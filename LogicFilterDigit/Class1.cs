using System;

namespace LogicFilterDigit
{
    public class FilterDigit
    {
        public static int[] Filter(int digit, params int[] numbers)
        {
            if ((digit < 0) || (digit > 9))
                throw new ArgumentException($"{nameof(digit)} must be from 0 to 9", nameof(digit));

            if (numbers == null)
                throw new ArgumentException(nameof(numbers));

            if (numbers.Length == 0)
                return null;

            int[] result = new int[0];
            string digitStr = digit.ToString();
            for (int i = 0; i < numbers.Length; i++)
            {
                string number = numbers[i].ToString();
                if (number.Contains(digitStr))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = numbers[i];
                }
            }

            return result;
        }

    }
}

