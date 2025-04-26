namespace HeroQuestGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Game
    {
        static void Main()
        {
            Hero hero = new Hero();
            RoomGraph map = new RoomGraph();
            ChallengeBST challenges = new ChallengeBST();

            map.GenerateRandomMap(15);
            while (!map.ValidatePath(1, 15))
            {
                map.GenerateRandomMap(15);
            }

            challenges.Insert(new Challenge { Difficulty = 3, Type = "Combat" });
            challenges.Insert(new Challenge { Difficulty = 7, Type = "Trap" });
            challenges.Insert(new Challenge { Difficulty = 12, Type = "Puzzle" });
            challenges.Insert(new Challenge { Difficulty = 15, Type = "Combat" });

            HashSet<int> completedChallenges = new HashSet<int>(); 
            Dictionary<int, Challenge> roomChallenges = new Dictionary<int, Challenge>();
            List<int> playerPath = new List<int>(); 

            int currentRoom = 1;

            Console.WriteLine("Welcome to the Adventure Game!");
            Console.WriteLine("Each time you play, the map will be different!");
            Console.WriteLine("Navigate using:");
            Console.WriteLine("  'H' to use Health Potion");
            Console.WriteLine("  'S' to use Strength Boost");
            Console.WriteLine("  'E' to exit the game");

            while (currentRoom != 15 && hero.Health > 0)
            {
                playerPath.Add(currentRoom); 
                Console.WriteLine($"\nYou are in Room {currentRoom}. Health: {hero.Health}");
                Console.WriteLine("Inventory: " + string.Join(", ", hero.Inventory));

                Console.WriteLine("\nAvailable Rooms: " + string.Join(", ", map.AdjacencyList[currentRoom]));
                Console.Write("Enter the number of the room you want to move into, or select an option ('H' for health, 'S' for strength, 'E' to exit): ");

                string command = Console.ReadLine().ToUpper();

                if (command == "E") break;
                if (command == "H") { hero.UseHealthPotion(); continue; }
                if (command == "S") { hero.UseStrengthBoost(); continue; }

                if (int.TryParse(command, out int selectedRoom) && map.AdjacencyList[currentRoom].Contains(selectedRoom))
                {
                    currentRoom = selectedRoom;

                    if (!completedChallenges.Contains(currentRoom))
                    {
                        Challenge challenge = challenges.FindClosest(currentRoom);
                        roomChallenges[currentRoom] = challenge;

                        Console.WriteLine($"\nRoom {currentRoom}: Facing {challenge.Type} (Difficulty: {challenge.Difficulty})");
                        Console.Write("Do you want to attempt the challenge? (Y/N): ");
                        string attempt = Console.ReadLine().ToUpper();

                        if (attempt == "Y")
                        {
                            bool success = hero.FaceChallenge(challenge.Type, challenge.Difficulty);
                            if (!success && hero.Health <= 0)
                            {
                                Console.WriteLine("You have lost all your health. Game over!");
                                PrintGamePaths(map, playerPath);
                                break;
                            }
                            completedChallenges.Add(currentRoom); 
                        }
                    }
                    else
                    {
                        Console.WriteLine("You've already completed the challenge in this room.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection! Choose a valid connected room.");
                }
            }

            if (hero.Health > 0 && currentRoom == 15)
            {
                Console.WriteLine("Congratulations! You reached the exit and won the game!");
            }
            else
            {
                Console.WriteLine("Game over. You lost.");
                PrintGamePaths(map, playerPath);
            }
        }

        static void PrintGamePaths(RoomGraph map, List<int> playerPath)
        {
            Console.WriteLine("\nCorrect Path to Win:");
            Console.WriteLine(string.Join(" -> ", map.CorrectPath));

            Console.WriteLine("\nYour Path Taken:");
            Console.WriteLine(string.Join(" -> ", playerPath));
        }
    }
}