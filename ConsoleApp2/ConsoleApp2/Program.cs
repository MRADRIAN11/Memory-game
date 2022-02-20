using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("Words.txt");

            var restart = false;

            do
            {
                restart = false;

                Console.WriteLine("Choose difficulty 1-easy 2-hard");
                Console.WriteLine("Quit? - write anything else or just enter");

                var chosen = Console.ReadLine();

                var game = new Game(lines);

                if (chosen == "1")
                {
                    game.start("easy");
                    Console.WriteLine("Restart? - write 1");
                    Console.WriteLine("Quit? - write anything else or just enter");

                    var r = Console.ReadLine();
                    if(r == "1")
                    {
                        restart = true;
                    }
                }
                else if (chosen == "2")
                {
                    game.start("hard");
                    Console.WriteLine("Restart? - write 1");
                    Console.WriteLine("Quit? - write anything else or just enter");

                    var r = Console.ReadLine();
                    if (r == "1")
                    {
                        restart = true;
                    }
                }
            } while (restart);
        }

      
    }
}
