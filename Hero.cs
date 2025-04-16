using System;
using System.Collections.Generic;

public class Hero
{
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }
    public int Health { get; set; } = 20;

    private Queue<string> Inventory = new Queue<string>();

    public Hero(int strength, int agility, int intelligence)
    {
        Strength = strength;
        Agility = agility;
        Intelligence = intelligence;

        // Add initial items
        AddItem("Sword");
        AddItem("Health Potion");
    }

    public void AddItem(string item)
    {
        if (Inventory.Count >= 5)
        {
            Console.WriteLine($"Inventory full! Removing {Inventory.Dequeue()} to add {item}.");
        }
        Inventory.Enqueue(item);
    }

    public void ShowInventory()
    {
        Console.WriteLine("Inventory: " + string.Join(", ", Inventory));
    }
}