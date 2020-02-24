using UnityEngine;

public class PlayerData
{

    public Vector3 location { get; set; }
    public string direction { get; set; }
    public string name { get; set; }
    public int health { get; set; }
    public int cash { get; set; }

    public PlayerData(Vector3 location,string direction, string name, int health, int cash)
    {
        this.location = location;
        this.direction = direction;
        this.name = name;
        this.health = health;
        this.cash = cash;
    }

    public override string ToString()
    {
        string tmp;

        tmp = "Location: " + this.location.ToString() + ", direction: " + this.direction + ", name: " + this.name + "...";
        return tmp;
    }
}