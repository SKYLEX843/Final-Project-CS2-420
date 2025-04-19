namespace HeroQuestGame
{
    public class Exploration
    {
        private Stack<int> VisitedRooms = new Stack<int>();
        private Stack<string> Treasures = new Stack<string>();
        private Dictionary<int, string> RoomChallenges = new Dictionary<int, string>();

        public void VisitRoom(int roomId, string challenge)
        {
            VisitedRooms.Push(roomId);
            RoomChallenges[roomId] = challenge;
            Console.WriteLine($"Entered Room {roomId}: Challenge - {challenge}");

            // Treasure system (10% chance)
            Random random = new Random();
            if (random.Next(1, 101) <= 10)
            {
                string treasure = random.Next(0, 2) == 0 ? "Gold" : "Gem";
                Treasures.Push(treasure);
                Console.WriteLine($"You found a treasure: {treasure}");
            }
        }

        public void DisplayVisitedRooms()
        {
            Console.WriteLine("Visited Rooms: " + string.Join(", ", VisitedRooms));
        }
    }
}