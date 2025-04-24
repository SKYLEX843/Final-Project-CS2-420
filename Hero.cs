namespace HeroQuestGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Hero
    {
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Health { get; set; } = 20;
        public Queue<string> Inventory { get; private set; } = new Queue<string>();

        public Hero()
        {
            Strength = 5;
            Agility = 5;
            Intelligence = 5;
            Inventory.Enqueue("Sword");
            Inventory.Enqueue("Health Potion");
        }

        // Adds an item to inventory (FIFO, max 5 items)
        public void AddItem(string item)
        {
            if (Inventory.Count >= 5) Inventory.Dequeue();
            Inventory.Enqueue(item);
        }

        // Uses health potion if available
        public void UseHealthPotion()
        {
            if (Inventory.Contains("Health Potion"))
            {
                // Remove potion from inventory
                Inventory = new Queue<string>(Inventory.Where(item => item != "Health Potion"));
                Health = Math.Min(Health + 10, 20); // Heal up to max 20
                Console.WriteLine($"You used a Health Potion! Your health is now {Health}.");
            }
            else
            {
                Console.WriteLine("You don't have a Health Potion to use.");
            }
        }

        // Uses strength boost if available
        public void UseStrengthBoost()
        {
            if (Inventory.Contains("Strength Boost"))
            {
                // Remove boost from inventory
                Inventory = new Queue<string>(Inventory.Where(item => item != "Strength Boost"));
                Strength += 2; // Increase strength temporarily
                Console.WriteLine($"You used a Strength Boost! Strength increased to {Strength}.");
            }
            else
            {
                Console.WriteLine("You don't have a Strength Boost to use.");
            }
        }

        public bool FaceChallenge(string challengeType, int difficulty)
        {
            int heroStat = challengeType.ToLower() switch
            {
                "combat" => Strength,
                "trap" => Agility,
                "puzzle" => Intelligence,
                _ => 0
            };

            if (heroStat >= difficulty)
            {
                Console.WriteLine($"Successfully overcame the {challengeType} challenge!");
                return true;
            }
            else
            {
                int damage = difficulty - heroStat;
                Health -= Math.Max(damage, 0);
                Console.WriteLine($"Challenge failed! Lost {damage} health.");
                return false;
            }
        }
    }
}