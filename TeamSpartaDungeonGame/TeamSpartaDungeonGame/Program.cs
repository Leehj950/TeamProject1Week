using TeamSpartaDungeonGame.Manager;

namespace TeamSpartaDungeonGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = GameManager.Instance();
            gameManager.StartGame();
        }
    }
}
