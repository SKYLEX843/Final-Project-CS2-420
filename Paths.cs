public bool IsPathExists(int start, int exit, Dictionary<int, Room> rooms)
{
    HashSet<int> visited = new HashSet<int>();
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(start);

    while (queue.Count > 0)
    {
        int current = queue.Dequeue();
        if (current == exit) return true;

        visited.Add(current);

        foreach (var neighbor in rooms[current].Neighbors)
        {
            if (!visited.Contains(neighbor))
            {
                queue.Enqueue(neighbor);
            }
        }
    }

    return false;
}