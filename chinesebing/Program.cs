using System.Text;

using static System.Console;
using static System.Math;

namespace chinesebing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Horsie");

            // tamzin code
            Console.OutputEncoding = Encoding.UTF8;

            const double AUS = 0.8085, US = 0.8272, POUND = 0.5457, YEN = 76.23, EURO = 0.6297;
            string temp;
            double NZD, AusFinal, UsFinal, PoundFinal, YenFinal, EuroFinal;

            Console.WriteLine("Give an amount of NZD");
            temp = Console.ReadLine();
            NZD = Convert.ToDouble(temp);
            AusFinal = NZD * AUS;
            UsFinal = NZD * US;
            PoundFinal = NZD * POUND;
            YenFinal = NZD * YEN;
            EuroFinal = NZD * EURO;
            Console.WriteLine($"{AusFinal:C} AUS");
            Console.WriteLine($"{UsFinal:C} US");
            Console.WriteLine($"£{PoundFinal:F2}");
            Console.WriteLine($"¥{YenFinal:F2}");
            Console.WriteLine($"€{EuroFinal:F2}");
            Console.ReadLine();
            
            // james code
            static void square()
            {
                CursorVisible = false;
                int bottomRow = WindowHeight - 1, farRow = WindowWidth - 1, x = 0, y = bottomRow - 1;
                bool go = true;

                SetCursorPosition(x, y);
                Write(new string('\u25A0', 5));
                while (go == true)
                {
                    bottomRow = WindowHeight - 1;
                    farRow = WindowWidth - 1;
                    x = Clamp(x, 0, farRow);
                    y = Clamp(y, 0, bottomRow - 1);


                    if (KeyAvailable)
                    {
                        bool moved = false;
                        var key = ReadKey(true).Key;


                        if ((key == ConsoleKey.RightArrow) && x < farRow)
                        {
                            x++;
                            moved = true;
                        }
                        else if ((key == ConsoleKey.LeftArrow) && (x > 0))
                        {
                            x--;
                            moved = true;
                        }
                        else if ((key == ConsoleKey.UpArrow) && (y > 0))
                        {
                            y--;
                            moved = true;
                        }
                        else if (key == ConsoleKey.DownArrow && (y < bottomRow - 1))
                        {
                            y++;
                            moved = true;
                        }

                        if (moved)
                        {
                            Clear();
                            SetCursorPosition(x, y);
                            Write(new string('\u25A0', 5));
                        }

                        if (key == ConsoleKey.Escape)
                        {
                            go = false;
                        }
                    }
                }
            }

            square();
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
