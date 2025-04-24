namespace HeroQuestGame
{
    using System;
    using System.Collections.Generic;

    class Game
    {
        static void Main()
        {
            Hero hero = new Hero();
            RoomGraph map = new RoomGraph();
            ChallengeBST challenges = new ChallengeBST();

            for (int i = 1; i <= 15; i++)
                map.AddEdge(i, i + 1);

            challenges.Insert(new Challenge { Difficulty = 3, Type = "Combat" });
            challenges.Insert(new Challenge { Difficulty = 7, Type = "Trap" });
            challenges.Insert(new Challenge { Difficulty = 12, Type = "Puzzle" });
            challenges.Insert(new Challenge { Difficulty = 15, Type = "Combat" });

            Stack<int> visitedRooms = new Stack<int>();
            Dictionary<int, Challenge> roomChallenges = new Dictionary<int, Challenge>();

            int currentRoom = 1;

            Console.WriteLine("Welcome to the Adventure Game!");
            Console.WriteLine("The controls for this game are:");
            Console.WriteLine("'W' to move forward");
            Console.WriteLine("'H' to use Health Potion");
            Console.WriteLine("'S' to use Strength Boost");
            Console.WriteLine("'E' to exit the game");

            while (currentRoom != 15 && hero.Health > 0)
            {
                Console.WriteLine($"\nYou are in Room {currentRoom}. Health: {hero.Health}");
                Console.WriteLine("Inventory: " + string.Join(", ", hero.Inventory));

                Console.WriteLine("Enter command ('W' to move forward, 'H' to use health potion, 'S' to use strength boost, 'E' to exit): ");
                string command = Console.ReadLine().ToUpper();
                if (command == "E") break;
                if (command == "H")
                {
                    hero.UseHealthPotion();
                    continue; 
                }
                if (command == "S")
                {
                    hero.UseStrengthBoost();
                    continue; 
                }

                if (command == "W")
                {
                    visitedRooms.Push(currentRoom);
                    Challenge challenge = challenges.FindClosest(currentRoom);
                    roomChallenges[currentRoom] = challenge;

                    Console.WriteLine($"Room {currentRoom}: Facing {challenge.Type} (Difficulty: {challenge.Difficulty})");
                    Console.WriteLine($"Do you want to attempt the challenge? (Y/N)");
                    string attempt = Console.ReadLine().ToUpper();

                    if (attempt == "Y")
                    {
                        bool success = hero.FaceChallenge(challenge.Type, challenge.Difficulty);

                        if (!success)
                        {
                            Console.WriteLine($"Your health is now {hero.Health}");
                            if (hero.Health <= 0)
                            {
                                Console.WriteLine("You have lost all your health. Game over!");
                                break;
                            }
                        }
                        else
                        {
                            Random rand = new Random();
                            if (rand.Next(0, 100) < 30)
                            {
                                Console.WriteLine("You earned a Strength Boost!");
                                hero.AddItem("Strength Boost");
                            }
                        }
                    }

                    currentRoom++;
                }
            }

            if (hero.Health > 0 && currentRoom == 15)
            {
                Console.WriteLine("Congratulations! You reached the exit and won the game!");
            }
            else
            {
                Console.WriteLine("Game over. You lost.");
            }
        }
    }
}