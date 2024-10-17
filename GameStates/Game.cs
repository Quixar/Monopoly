using System.Collections;

class Game : IEnumerable
{
    public List<Player> players;
    public int currentPlayer;
    public Map map;
    public GameStateRenderer gameStateRenderer;
    IState currentState;

    public Game()
    {
        gameStateRenderer = new GameStateRenderer();
        map = new Map();
        players = new List<Player>();
        currentPlayer = 0;
        currentState = new MainMenuState();
    }

    public IEnumerator GetEnumerator()
    {
        return new PlayerEnumerator(players);
    }

    public Player this[int index]
    {
        get
        {
            if(index >= 0 && index < players.Count)
            {
                return players[index];
            }
            throw new ArgumentOutOfRangeException("Invalid index");
        }
    }

    public void NextPlayer()
    {
        currentPlayer = (currentPlayer + 1) % players.Count;
    }

    public void ChangeState(IState newState)
    {
        currentState = newState;
    }

    public void HandleInput()
    {
        currentState.HandleInput(this);
    }

    public void Render()
    {
        currentState.Render();
    }

    public void RemovePlayer(Player player)
    {
        players.Remove(player);
        System.Console.WriteLine($"{player.Name} declared bankrupt and removed from the game");
    }
}