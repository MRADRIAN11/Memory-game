using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Game
{
    public List<int> Chosen { get; set; }
    public string Difficulty { get; set; }
    public int Attempts { get; set; }
    public int NbPairs { get; set; }
    public string[] Lines { get; set; }
    public Stopwatch Stopwatch { get; set; }

    public Game(string[] lines)
	{
        Chosen = new List<int>();
        this.Lines = lines;
        Stopwatch = new Stopwatch();
	}

    public void start(string df)
    {
        Stopwatch.Start();

        var list = new List<string>();
        Difficulty = df;
        Random r = new Random();

        if(Difficulty == "easy")
        {
            Attempts = 10;
            NbPairs = 4;
        }
        else if(Difficulty == "hard")
        {
            Attempts = 15;
            NbPairs = 8;
        }

        for (int i = 0; i < NbPairs; i++)
        {
            var rnd = r.Next(0, Lines.Length);
            list.Add(Lines[rnd]);
            list.Add(Lines[rnd]);
        }

        var randomized = list.OrderBy(item => r.Next()).ToList();

        for (int i = Attempts; i > 0; i--)
        {
            step(randomized, i);
            if(Chosen.Count == randomized.Count)
            {
                Stopwatch.Stop();
                TimeSpan ts = Stopwatch.Elapsed;
                Console.WriteLine("Congratulations!!! You Won!");
                Console.WriteLine($"Attempts: {Attempts-i} Time: {ts.Minutes}:{ts.Seconds}\n\n");
                saveScore(Attempts - i, ts);
                break;
            }
        }
        if (Chosen.Count != randomized.Count)
        {
            Console.WriteLine("You lose!");
        }

    }

    private void saveScore(int attempts, TimeSpan ts)
    {
        Console.Write("Your name: ");
        var name = Console.ReadLine();
        List<Score> scores= new List<Score>();

        if (System.IO.File.Exists("scores.txt"))
        {
            scores = System.IO.File.ReadAllLines("scores.txt").ToList().ConvertAll(x => { var item = new Score();
                item.convert(x);
                return item;
            }) ;
        }
        var data = new Score();

        data.Name = name;
        data.Date = DateTime.Today;
        data.Ts = ts;
        data.Attempts = attempts;

        scores.Add(data);

        scores = scores.OrderBy(i => i.Ts).ThenBy(i => i.Attempts).ToList();

        while(scores.Count > 10)
        {
            scores.RemoveAt(scores.Count - 1);
        }

        for(int i = 0; i < scores.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scores[i]}");
        }

        System.IO.File.WriteAllLines("scores.txt", scores.ConvertAll(x => x.ToString()));
    }

    private void step(List<string> randomized, int guess)
    {
        showBoard(randomized, guess);
        var input = Console.ReadLine();
        convertPick(input);

        showBoard(randomized, guess);
        input = Console.ReadLine();
        convertPick(input);

        showBoard(randomized, guess);

        if (Chosen.Contains(-1) || randomized[Chosen[Chosen.Count - 1]] != randomized[Chosen[Chosen.Count - 2]])
        {
            Chosen.RemoveAt(Chosen.Count - 1);
            Chosen.RemoveAt(Chosen.Count - 1);
        }
    }

    private void convertPick(string input)
    {
        if(Difficulty == "easy")
        {
            switch (input)
            {
                case "A1":
                case "a1":
                    Chosen.Add(0);
                    break;
                case "A2":
                case "a2":
                    Chosen.Add(1);
                    break;
                case "A3":
                case "a3":
                    Chosen.Add(2);
                    break;
                case "A4":
                case "a4":
                    Chosen.Add(3);
                    break;
                case "B1":
                case "b1":
                    Chosen.Add(4);
                    break;
                case "B2":
                case "b2":
                    Chosen.Add(5);
                    break;
                case "B3":
                case "b3":
                    Chosen.Add(6);
                    break;
                case "B4":
                case "b4":
                    Chosen.Add(7);
                    break;
                default:
                    Chosen.Add(-1);
                    break;

            }
        }

        if (Difficulty == "hard")
        {
            switch (input)
            {
                case "A1":
                case "a1":
                    Chosen.Add(0);
                    break;
                case "A2":
                case "a2":
                    Chosen.Add(1);
                    break;
                case "A3":
                case "a3":
                    Chosen.Add(2);
                    break;
                case "A4":
                case "a4":
                    Chosen.Add(3);
                    break;
                case "B1":
                case "b1":
                    Chosen.Add(4);
                    break;
                case "B2":
                case "b2":
                    Chosen.Add(5);
                    break;
                case "B3":
                case "b3":
                    Chosen.Add(6);
                    break;
                case "B4":
                case "b4":
                    Chosen.Add(7);
                    break;
                case "C1":
                case "c1":
                    Chosen.Add(8);
                    break;
                case "C2":
                case "c2":
                    Chosen.Add(9);
                    break;
                case "C3":
                case "c3":
                    Chosen.Add(10);
                    break;
                case "C4":
                case "c4":
                    Chosen.Add(11);
                    break;
                case "D1":
                case "d1":
                    Chosen.Add(12);
                    break;
                case "D2":
                case "d2":
                    Chosen.Add(13);
                    break;
                case "D3":
                case "d3":
                    Chosen.Add(14);
                    break;
                case "D4":
                case "d4":
                    Chosen.Add(15);
                    break;
                default:
                    Chosen.Add(-1);
                    break;

            }
        }

    }

    private void showBoard(List<string> randomized, int guess) 
    {
        Console.WriteLine("—-----------------------------------");
        Console.WriteLine($"         Level: {Difficulty}");
        Console.WriteLine($"         Guess chances: {guess}\n");
        Console.WriteLine("  1 2 3 4");
       
        for (int i = 0; i < randomized.Count; i++)
        {
            if(i==0)
            {
                Console.Write("A ");
            }
            if (i == 4)
            {
                Console.Write("\nB ");
            }
            if (i == 8)
            {
                Console.Write("\nC ");
            }
            if (i == 12)
            {
                Console.Write("\nD ");
            }

            if (Chosen.Contains(i))
            {
                Console.Write(randomized[i] + " ");
            }
            else
            {
                Console.Write("X ");
            }
        }
        Console.WriteLine("\n—-----------------------------------");
    }

}
