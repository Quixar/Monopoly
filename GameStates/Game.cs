using System.Collections;

class Game : IEnumerable
{
    public List<Player> players;
    public int currentPlayer;
    IGameState currentState;

    public Game(IGameState initState, List<Player> players)
    {
        this.players = players;
        currentPlayer = 0;
        currentState = initState;
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

    public void ChangeState(IGameState newState)
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
}