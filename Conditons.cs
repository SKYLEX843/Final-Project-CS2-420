public class GameEnd
{
    public static void CheckWinningConditions(Hero hero, int currentRoom, int exitRoom, Exploration exploration)
    {
        if (hero.Health > 0 && currentRoom == exitRoom)
        {
            Console.WriteLine("You win! You've reached the exit with health remaining.");
        }
        else if (hero.Health <= 0)
        {
            Console.WriteLine("You lost! Your health reached 0.");
            exploration.DisplayVisitedRooms();
        }
    }
}