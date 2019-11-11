using System;

namespace AirWorldWide
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var results = Validate(args);

            if (!string.IsNullOrEmpty(results.Item2))
                Console.WriteLine(results.Item2);
            else
                CountBackWards(results.Item1[0], results.Item1[1]);

            // Console.WriteLine();
        }

        /// <summary>
        /// Validate the specified inputs.
        /// </summary>
        /// <returns>The validate.</returns>
        /// <param name="input">Space separated numbers.</param>
        private static (int[], string) Validate(string[] input)
        {
            string validation;
            string[] strinputs = input;
            int[] numbers = new int[2];

            bool isfirstint = int.TryParse(strinputs[0], out int first);
            if (!isfirstint)
            {
                validation = "Input is not a valid integer";
                return (numbers, validation);
            }

            bool issecondint = int.TryParse(strinputs[1], out int second);
            if (!issecondint)
            {
                validation = "Input is not a valid integer";
                return (numbers, validation);
            }

            if (first < 0 || second < 0)
            {
                validation = "Enter positive numbers";
                return (numbers, validation);
            }

            if (first < 2)
            {
                validation = "Please enter a first number which is > 2";
                return (numbers, validation);
            }

            if (second == 0)
            {
                validation = "Please enter a second number which is > 0";
                return (numbers, validation);
            }

            if (first < second)
            {
                validation = "Please enter a second number which is < first";
                return (numbers, validation);
            }

            if (first % second != 0)
            {
                validation = "Please enter 2 numbers where first is divisible by second";
                return (numbers, validation);
            }

            if (first > 1000)
            {
                validation = "Enter first number <= 1000";
                return (numbers, validation);
            }
            else
            {
                numbers[0] = first;
                numbers[1] = second;
            }

            return (numbers, null);

        }

        private static void CountBackWards(int first, int second)
        {
            while (first > 0)
            {
                if (first % second == 0)
                    Console.Write(first + " ");

                first--;
            }
        }
    }
}