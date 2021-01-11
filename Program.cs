using System;
using System.Text;
using System.Collections.Generic;
 
public class Card
{
    private static int cardNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; }
    public List<Trace> allTraces = new List<Trace>();
    public decimal Distance
    {
        get
        {
            decimal distance = 0;
            foreach (var item in allTraces)
            {
                distance += item.Kilometers;
            }
 
            return distance;
        }
    }
    public Card(string owner)
    {
        this.Owner = owner;
        this.Number = cardNumberSeed.ToString();
        cardNumberSeed++;
    }
 
    public void RegisterNewTrace(decimal kilometers, string note)
    {
        var trace = new Trace(kilometers, note);
        allTraces.Add(trace);
        // Console.WriteLine($"Dodano: {trace.Kilometers}km. \nData: {trace.date.Day}.{trace.date.Month}.{trace.date.Year}. \nNotatka: {trace.Note}");
    }
 
    public string GetAccountHistory()
    {
        string trace = "";
        decimal allKilometers = 0;
        foreach (var tr in allTraces)
        {
            string tmpWycieczka = $"Dystans:\t\t{tr.Kilometers}km.\nData: \t\t\t{tr.date.Day}.{tr.date.Month}.{tr.date.Year}.\nOpis: \t\t\t{tr.Note}\n";
            allKilometers += tr.Kilometers;
            string tmpPart2Wycieczka = $"\nSuma kilometrów: \t {allKilometers}km.\n\n";
            trace += tmpWycieczka + tmpPart2Wycieczka;
        }
        return trace;
    }
 
    public string GetAccountHistoryWithStringBuilder()
    {
        StringBuilder sb = new StringBuilder();
        decimal allKilometers = 0;
        foreach (var tr in allTraces)
        {
            sb.AppendLine($"Dystans:\t\t{tr.Kilometers}km.");
            sb.AppendLine($"Data: \t\t\t{tr.date.Day}.{tr.date.Month}.{tr.date.Year}.");
            sb.AppendLine($"Opis: \t\t\t{tr.Note}\n");
            allKilometers += tr.Kilometers;
            sb.AppendLine($"Suma kilometrów: \t{allKilometers}km.");
        }
        return sb.ToString();
    }
}