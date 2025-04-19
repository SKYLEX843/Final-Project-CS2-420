namespace HeroQuestGame
{
public class Room
{
    public int Id { get; set; }
    public List<int> Neighbors { get; set; } = new List<int>();
    public int Challenge { get; set; }
    public Room(int id, int challenge)
    {
        Id = id;
        Challenge = challenge;
    }
}

public class Map
{
    private Dictionary<int, Room> Rooms = new Dictionary<int, Room>();

    public void AddRoom(int id, int challenge)
    {
        Rooms[id] = new Room(id, challenge);
    }

    public void AddPath(int from, int to)
    {
        Rooms[from].Neighbors.Add(to);
        Rooms[to].Neighbors.Add(from);
    }

    public void DisplayMap()
    {
        foreach (var room in Rooms.Values)
        {
            Console.WriteLine($"Room {room.Id} (Challenge {room.Challenge}): Connected to {string.Join(", ", room.Neighbors)}");
        }
    }

    public Room GetRoom(int id) => Rooms.ContainsKey(id) ? Rooms[id] : null;
}
}