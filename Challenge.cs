public class ChallengeNode
{
    public string Challenge { get; set; }
    public ChallengeNode Left { get; set; }
    public ChallengeNode Right { get; set; }

    public ChallengeNode(string challenge)
    {
        Challenge = challenge;
    }
}

public class ChallengeTree
{
    public ChallengeNode Root { get; set; }

    public void AddChallenge(string challenge)
    {
        Root = AddChallenge(Root, challenge);
    }

    private ChallengeNode AddChallenge(ChallengeNode node, string challenge)
    {
        if (node == null) return new ChallengeNode(challenge);

        if (string.Compare(challenge, node.Challenge) < 0)
        {
            node.Left = AddChallenge(node.Left, challenge);
        }
        else
        {
            node.Right = AddChallenge(node.Right, challenge);
        }

        return node;
    }

    public void DisplayChallenges(ChallengeNode node)
    {
        if (node == null) return;
        DisplayChallenges(node.Left);
        Console.WriteLine(node.Challenge);
        DisplayChallenges(node.Right);
    }
}