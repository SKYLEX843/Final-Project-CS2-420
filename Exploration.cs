using System;
using System.Collections.Generic;

public class Exploration
{
    private Stack<int> VisitedRooms = new Stack<int>();
    private Dictionary<int, string> RoomData = new Dictionary<int, string>(); // Room to challenge mapping

    public void VisitRoom(int roomId, string challenge)
    {
        VisitedRooms.Push(roomId);
        RoomData[roomId] = challenge;
        Console.WriteLine($"Entered Room {roomId}: Challenge - {challenge}");
    }

    public void Backtrack()
    {
        if (VisitedRooms.Count > 0)
        {
            int lastRoom = VisitedRooms.Pop();
            Console.WriteLine($"Backtracked from Room {lastRoom}");
        }
        else
        {
            Console.WriteLine("No rooms to backtrack from!");
        }
    }

    public void DisplayVisitedRooms()
    {
        Console.WriteLine("Visited Rooms: " + string.Join(", ", VisitedRooms));
    }

    public string GetChallenge(int roomId)
    {
        if (RoomData.TryGetValue(roomId, out string challenge))
        {
            return challenge;
        }
        return "No challenge found!";
    }
}