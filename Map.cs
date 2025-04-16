using System;
using System.Collections.Generic;

public class Room
{
    public int Id { get; set; }
    public List<int> Neighbors { get; set; } = new List<int>();
    public string Challenge { get; set; } // Placeholder for BST integration

    public Room(int id)
    {
        Id = id;
    }
}

public class Map
{
    private Dictionary<int, Room> Rooms = new Dictionary<int, Room>();

    public void AddRoom(int id)
    {
        if (!Rooms.ContainsKey(id))
        {
            Rooms[id] = new Room(id);
        }
    }

    public void AddPath(int from, int to)
    {
        if (Rooms.ContainsKey(from) && Rooms.ContainsKey(to))
        {
            Rooms[from].Neighbors.Add(to);
            Rooms[to].Neighbors.Add(from);
        }
    }

    public void DisplayMap()
    {
        foreach (var room in Rooms.Values)
        {
            Console.WriteLine($"Room {room.Id}: Connected to {string.Join(", ", room.Neighbors)}");
        }
    }
}

//

