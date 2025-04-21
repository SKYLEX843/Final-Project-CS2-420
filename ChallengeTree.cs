namespace HeroQuestGame
{
    public class ChallengeTree
    {
        public ChallengeNode Root { get; set; }

        public void AddChallenge(int difficulty)
        {
            Root = AddChallenge(Root, difficulty);
        }

        private ChallengeNode AddChallenge(ChallengeNode node, int difficulty)
        {
            if (node == null) return new ChallengeNode(difficulty);
            if (difficulty < node.Difficulty)
                node.Left = AddChallenge(node.Left, difficulty);
            else
                node.Right = AddChallenge(node.Right, difficulty);
            return node;
        }

        public int FindClosest(int target)
        {
            return FindClosest(Root, target);
        }

        private int FindClosest(ChallengeNode node, int target)
        {
            if (node == null) return -1;
            if (node.Difficulty == target) return node.Difficulty;

            int bestMatch = node.Difficulty;
            if (target < node.Difficulty && node.Left != null)
                bestMatch = FindClosest(node.Left, target);
            else if (target > node.Difficulty && node.Right != null)
                bestMatch = FindClosest(node.Right, target);

            return bestMatch;
        }
    }
}