namespace HeroQuestGame
{
    class Challenge
    {
        public int Difficulty { get; set; }
        public string Type { get; set; }
    }

    class ChallengeBSTNode
    {
        public Challenge Challenge { get; set; }
        public ChallengeBSTNode Left { get; set; }
        public ChallengeBSTNode Right { get; set; }

        public ChallengeBSTNode(Challenge challenge) { Challenge = challenge; }
    }

    class ChallengeBST
    {
        public Challenge FindClosest(int targetDifficulty)
        {
            return FindClosest(Root, targetDifficulty);
        }

        private Challenge FindClosest(ChallengeBSTNode node, int targetDifficulty)
        {
            if (node == null) return null;

            Challenge bestMatch = node.Challenge;
            if (targetDifficulty < node.Challenge.Difficulty && node.Left != null)
            {
                Challenge leftMatch = FindClosest(node.Left, targetDifficulty);
                if (Math.Abs(leftMatch.Difficulty - targetDifficulty) < Math.Abs(bestMatch.Difficulty - targetDifficulty))
                    bestMatch = leftMatch;
            }
            else if (targetDifficulty > node.Challenge.Difficulty && node.Right != null)
            {
                Challenge rightMatch = FindClosest(node.Right, targetDifficulty);
                if (Math.Abs(rightMatch.Difficulty - targetDifficulty) < Math.Abs(bestMatch.Difficulty - targetDifficulty))
                    bestMatch = rightMatch;
            }

            return bestMatch;
        }
        public ChallengeBSTNode Root { get; private set; }

        public void Insert(Challenge challenge)
        {
            Root = Insert(Root, challenge);
        }

        private ChallengeBSTNode Insert(ChallengeBSTNode node, Challenge challenge)
        {
            if (node == null) return new ChallengeBSTNode(challenge);

            if (challenge.Difficulty < node.Challenge.Difficulty)
                node.Left = Insert(node.Left, challenge);
            else
                node.Right = Insert(node.Right, challenge);

            return node;
        }

        public void Delete(int difficulty)
        {
            Root = Delete(Root, difficulty);
        }

        private ChallengeBSTNode Delete(ChallengeBSTNode node, int difficulty)
        {
            if (node == null) return null;

            if (difficulty < node.Challenge.Difficulty)
                node.Left = Delete(node.Left, difficulty);
            else if (difficulty > node.Challenge.Difficulty)
                node.Right = Delete(node.Right, difficulty);
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                ChallengeBSTNode temp = FindMin(node.Right);
                node.Challenge = temp.Challenge;
                node.Right = Delete(node.Right, temp.Challenge.Difficulty);
            }

            return node;
        }

        private ChallengeBSTNode FindMin(ChallengeBSTNode node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }
    }
}