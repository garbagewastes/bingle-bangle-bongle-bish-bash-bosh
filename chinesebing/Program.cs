namespace chinesebing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Horsie");

            // tamzin code

            // james code

            // quinn code

            int horseDistance = 0, playerDistance = 0, round = 0, roundDistance;

            Console.WriteLine("the 100m horse race is about to begin,\n\nyou and the computer will spin random numbers to race ahead to 101m or more");
            Console.WriteLine("the player will spin first each round");
            Console.ReadLine();
            do
            {
                round++;
                Console.Clear();
                Console.WriteLine($"\n\t|round {round}|\n\nplayer is at {playerDistance}m, and computer is at {horseDistance}m\n");
                Console.Write($"player turn, hit ENTER to spin (1-10m) ");
                Console.ReadLine();

                roundDistance = spin();
                playerDistance += roundDistance;
                if (playerDistance % 20 == 0)
                {
                    Console.WriteLine($"player hit a puddle at {playerDistance}m, falls back to {playerDistance - 4}m");
                    playerDistance -= 4;
                }
                else if (playerDistance % 35 == 0)
                {
                    Console.WriteLine($"player's horse got a burst of energy  at {playerDistance} and jumped an extra 6m to {playerDistance + 6}m");
                    playerDistance += 6;
                }
                else Console.WriteLine($"\tplayer reaches {playerDistance}m");
                Thread.Sleep(1000);

                Console.WriteLine("computer turn");
                Thread.Sleep(1000);

                roundDistance = spin();
                horseDistance += roundDistance;
                if (horseDistance % 20 == 0)
                {
                    Console.WriteLine($"computer hit a puddle at {horseDistance}m, falls back to {horseDistance - 4}m");
                    horseDistance -= 4;
                }
                else if (horseDistance % 35 == 0)
                {
                    Console.WriteLine($"computer's horse got a burst of energy  at {horseDistance} and jumped an extra 6m to {horseDistance + 6}m");
                    horseDistance += 6;
                }
                else Console.WriteLine($"\tcomputer reaches {horseDistance}m");
                Console.ReadLine();

            } while (horseDistance < 100 && playerDistance < 100);

            if (playerDistance > 100) Console.WriteLine("player makes it past 100m, and wins the race");
            else Console.WriteLine("computer makes it past 100m, and wins the race");
            Console.ReadLine();

            static int spin()
            {
                int num;
                Random rand = new Random();
                num = rand.Next(1, 11);
                Console.Write("spinning wheel");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(300);
                    Console.Write(".");
                }
                Console.WriteLine($"\n\tmoves forward {num}m");
                return num;
            }
            Console.ReadLine();
        }
    }
}
