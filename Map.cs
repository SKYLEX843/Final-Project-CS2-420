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
    }
}