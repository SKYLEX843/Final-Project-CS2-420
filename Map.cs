namespace HeroQuestGame
{
    class RoomGraph
    {
        public Dictionary<int, List<int>> AdjacencyList { get; private set; } = new Dictionary<int, List<int>>();

        public void AddEdge(int room1, int room2)
        {
            if (!AdjacencyList.ContainsKey(room1)) AdjacencyList[room1] = new List<int>();
            if (!AdjacencyList.ContainsKey(room2)) AdjacencyList[room2] = new List<int>();

            AdjacencyList[room1].Add(room2);
            AdjacencyList[room2].Add(room1);
        }

        // Added validation to ensure exit path exists
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
    }
}