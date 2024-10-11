class Player
{
    public Wallet wallet;
    Map map;
    int currentPosition;

    public Player(Map map)
    {
        this.map = map;
        currentPosition = 0;
    }

    public void NextStep()
    {
        this.map[currentPosition].OnStep(this); 
    }
}