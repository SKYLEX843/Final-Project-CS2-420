using System;

public class Treasure
{
    private Stack<string> Treasures = new Stack<string>();

    public void FindTreasure()
    {
        Random random = new Random();
        if (random.Next(1, 101) <= 10) // 10% chance
        {
            string treasure = random.Next(0, 2) == 0 ? "Gold" : "Gem";
            Treasures.Push(treasure);
            Console.WriteLine($"You found a treasure: {treasure}");
        }
        else
        {
            Console.WriteLine("No treasure in this room.");
        }
    }

    public void UseTreasure()
    {
        if (Treasures.Count > 0)
        {
            string treasure = Treasures.Pop();
            Console.WriteLine($"Used treasure: {treasure}");
        }
        else
        {
            Console.WriteLine("No treasures to use.");
        }
    }

    public void DisplayTreasures()
    {
        Console.WriteLine("Treasures: " + string.Join(", ", Treasures));
    }
}