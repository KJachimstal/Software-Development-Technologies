using System;

public class Game
{
    public enum GameType { POKER, BRIDGE, ROULETTE }

    private int id;

    public int Id {
        get { return id; }
        set { id = value; }
    }

    private string name;

    public string Name {
        get { return name; }
        set { name = value; }
    }

    private GameType type;

    public GameType Type {
        get { return type; }
        set { type = value; }
    }

}