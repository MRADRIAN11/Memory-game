using System;
using System.Collections.Generic;
using System.Text;

class Score
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Ts { get; set; }
    public int Attempts { get; set; }


    public Score()
    {
            
    }

    public void convert(string score)
    {
        var splits = score.Split("|");

        Name = splits[0];
        Date = DateTime.Parse(splits[1]);
        Ts = TimeSpan.Parse(splits[2]);
        Attempts = Convert.ToInt32(splits[3]);
    }

    public override string ToString()
    {
        return $"{Name}|{Date.Day}.{Date.Month}.{Date.Year}|{Ts.Hours}:{Ts.Minutes}:{Ts.Seconds}|{Attempts}";
    }
}
