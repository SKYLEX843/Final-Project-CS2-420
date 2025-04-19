namespace HeroQuestGame
{
    public class ChallengeNode
    {
        public int Difficulty { get; set; }
        public ChallengeNode Left { get; set; }
        public ChallengeNode Right { get; set; }

        public ChallengeNode(int difficulty)
        {
            Difficulty = difficulty;
        }
    }
}