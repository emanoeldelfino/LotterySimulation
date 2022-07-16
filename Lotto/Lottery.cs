using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery
{
    public class Lottery
    {
        private Random rnd = new Random();
        private int size;
        private int start;
        private int end;
        private bool repeat;

        public Lottery(int size, int start, int end, bool repeat = false)
        {
            this.size = size;
            this.start = start;
            this.end = end + 1;
            this.repeat = repeat;

            if (start > end)
                throw new ArgumentException("Invalid arguments: start must be less than end.");

            if (!repeat && ((end - start) + 1) < size)
                throw new ArgumentException("Invalid arguments: no repeating numbers must have end/start difference greater than size");
        }

        public List<int> sortNums()
        {
            List<int> nums = new List<int>();

            for (int i = 0; i < size; i++)
            {
                int num;

                do
                    num = rnd.Next(start, end);
                while (!repeat && nums.Contains(num));

                nums.Add(num);
            }

            nums.Sort();

            return nums;
        }

        public string numsToString(List<int> nums)
        {
            return String.Join(", ", nums.Select(num => num.ToString("00")));
        }

        public void Simulate(int numGames)
        {
            int numWins = 0;

            for (int i = 1; i <= numGames; i++)
            {
                List<int> sortedNums = sortNums();
                List<int> playerNums = sortNums();

                if (sortedNums.All(playerNums.Contains))
                {
                    numWins++;
                    Console.WriteLine($"\nGAME {i}");
                    Console.WriteLine($"Sorted Nums: {numsToString(sortedNums)}");
                    Console.WriteLine($"Player Nums: {numsToString(playerNums)}");
                    Console.WriteLine("JACKPOT WON!!!");
                }
            }

            Console.WriteLine($"\nNumber of Wins: {numWins}.");
        }
    }
}
