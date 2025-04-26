using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroQuestGame
{
    class RoomGraph
    {
        public Dictionary<int, List<int>> AdjacencyList { get; private set; } = new Dictionary<int, List<int>>();
        public List<int> CorrectPath { get; private set; } = new List<int>(); 

        public void GenerateRandomMap(int totalRooms)
        {
            Random rand = new Random();
            List<int> rooms = Enumerable.Range(1, totalRooms).OrderBy(x => rand.Next()).ToList();

            for (int i = 0; i < rooms.Count - 1; i++)
            {
                AddEdge(rooms[i], rooms[i + 1]);
                if (i > 0 && rand.Next(0, 100) < 40) AddEdge(rooms[i], rand.Next(1, totalRooms + 1));
            }

            FindWinningPath(1, 15); 
        }

        public void AddEdge(int room1, int room2)
        {
            if (!AdjacencyList.ContainsKey(room1)) AdjacencyList[room1] = new List<int>();
            if (!AdjacencyList.ContainsKey(room2)) AdjacencyList[room2] = new List<int>();

            AdjacencyList[room1].Add(room2);
            AdjacencyList[room2].Add(room1);
        }

        public bool ValidatePath(int start, int end)
        {
            HashSet<int> visited = new HashSet<int>();
            return DFS(start, end, visited);
        }

        private bool DFS(int current, int target, HashSet<int> visited)
        {
            if (current == target) return true;
            if (!AdjacencyList.ContainsKey(current) || visited.Contains(current)) return false;

            visited.Add(current);
            foreach (var neighbor in AdjacencyList[current])
            {
                if (DFS(neighbor, target, visited)) return true;
            }
            return false;
        }

        private void FindWinningPath(int start, int end)
        {
            CorrectPath.Clear();
            Dictionary<int, int> previousRoom = new Dictionary<int, int>();
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (current == end) break;

                foreach (int neighbor in AdjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        previousRoom[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            int pathRoom = end;
            while (previousRoom.ContainsKey(pathRoom))
            {
                CorrectPath.Insert(0, pathRoom);
                pathRoom = previousRoom[pathRoom];
            }
            CorrectPath.Insert(0, start);
        }
    }
}