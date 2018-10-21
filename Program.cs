using System;
using System.Diagnostics;
using System.Text;

namespace CoinTossStreakSimulator
{
    class Program
    {
        private static Random random = new Random();

        /**
         * Pass any parameter to activate debug logs.
         */
        static void Main(string[] args)
        {
            // Debug can represent a significant performance hit on huge numbers.
            bool debug = args.Length > 0;

            char answer;

            do
            {
                Console.Write("How many tosses? ");

                int count;
                bool isValid = false;
                var debugOutput = new StringBuilder();

                do
                {
                    isValid = Int32.TryParse(Console.ReadLine(), out count);
                    if (!isValid) Console.WriteLine("This is not a number.");
                } while (!isValid);

                int currentStreak = 1;
                int maxStreak = currentStreak;

                bool? previousValue = null;

                for (int i = 0; i < count; i++)
                {
                    bool toss = TossCoin();
                    if(debug) debugOutput.Append($"{toss} ");

                    if (toss == previousValue)
                    {
                        currentStreak++;
                        if (currentStreak > maxStreak) maxStreak = currentStreak;
                    }
                    else currentStreak = 1;

                    previousValue = toss;
                }

                Console.WriteLine($"Max streak for {count}: {maxStreak}.");
                if (debug) Debug.WriteLine($"{debugOutput} - Max streak for {count}: {maxStreak}.");

                Console.Write("Again? (y/n) ");

                answer = Console.ReadKey().KeyChar;
                Console.WriteLine();

            } while (answer == 'y');
        }


        /**
         * Simulates a coin toss by using random.
         * 
         * @returns A random boolean.
         */
        private static bool TossCoin()
        {
            return random.NextDouble() >= 0.5;
        }
    }
}
