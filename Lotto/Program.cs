using System;

namespace Lottery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lottery lottery = new Lottery(6, 1, 60);

            Console.Write("Number of games: ");
            int numGames = Convert.ToInt32(Console.ReadLine());

            lottery.Simulate(numGames);

            Console.WriteLine("\nHit any key to exit ");
            Console.ReadLine();
        }
    }
}
