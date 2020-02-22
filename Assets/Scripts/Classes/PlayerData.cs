using UnityEngine;

public class PlayerData
{

    public Vector3 location { get; set; }
    public string name { get; set; }
    public int health { get; set; }
    public int cash { get; set; }

    public PlayerData(Vector3 location, string name, int health, int cash)
    {
        this.location = location;
        this.name = name;
        this.health = health;
        this.cash = cash;
    }

}