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

        public void AddItem(string item)
        {
            if (Inventory.Count >= 5) Inventory.Dequeue();
            Inventory.Enqueue(item);
        }

        public void UseHealthPotion()
        {
            if (Inventory.Contains("Health Potion"))
            {
                Inventory = new Queue<string>(Inventory.Where(item => item != "Health Potion"));
                Health = Math.Min(Health + 10, 20); 
                Console.WriteLine($"You used a Health Potion! Your health is now {Health}.");
            }
            else
            {
                Console.WriteLine("You don't have a Health Potion to use.");
            }
        }
        public void UseStrengthBoost()
        {
            if (Inventory.Contains("Strength Boost"))
            {
                Inventory = new Queue<string>(Inventory.Where(item => item != "Strength Boost"));
                Strength += 2; 
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