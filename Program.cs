using System;

namespace HeroQuestGame
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Hero's Quest!");

            Hero hero = new Hero(10, 8, 9);

            Map map = new Map();
            Exploration exploration = new Exploration();
            ChallengeTree bst = new ChallengeTree();

            for (int i = 1; i <= 15; i++)
            {
                int difficulty = new Random().Next(1, 21);
                map.AddRoom(i, difficulty);
                bst.AddChallenge(difficulty);
            }

            for (int i = 1; i < 15; i++)
            {
                map.AddPath(i, i + 1);
            }

            int currentRoom = 1;
            int exitRoom = 15;

            while (currentRoom != exitRoom && hero.Health > 0)
            {
                Room room = map.GetRoom(currentRoom);
                int closestChallenge = bst.FindClosest(room.Challenge);
                Console.WriteLine($"Facing challenge difficulty {closestChallenge}...");

                if (hero.Strength >= closestChallenge)
                {
                    Console.WriteLine("Challenge passed!");
                }
                else
                {
                    int damage = closestChallenge - hero.Strength;
                    hero.Health -= damage;
                    Console.WriteLine($"Challenge failed! Lost {damage} health. Remaining Health: {hero.Health}");
                }

                exploration.VisitRoom(currentRoom, $"Difficulty {closestChallenge}");
                currentRoom++;
            }

            if (hero.Health > 0)
                Console.WriteLine("You win! You reached the exit!");
            else
            {
                Console.WriteLine("You lost! Health reached 0.");
                exploration.DisplayVisitedRooms();
            }
        }
    }
}