using System.Collections;

class PlayerEnumerator : IEnumerator
{
    private List<Player> players;
    private int position = -1;

    public PlayerEnumerator(List<Player> players)
    {
        this.players = players;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Player Current
    {
        get
        {
            if (position < 0 || position >= players.Count)
                throw new InvalidOperationException();
            return players[position];
        }
    }

    public bool MoveNext()
    {
        if (position < players.Count - 1)
        {
            position++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        position = -1;
    }
}
