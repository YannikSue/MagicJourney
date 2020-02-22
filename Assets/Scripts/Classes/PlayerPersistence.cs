
using UnityEngine;

public static class PlayerPersistence
{


    public static void StoreData(Player player)
    {

        PlayerPrefs.SetFloat("x", player.transform.position.x);
        PlayerPrefs.SetFloat("y", player.transform.position.y);
        PlayerPrefs.SetFloat("z", player.transform.position.z);
        PlayerPrefs.SetString("name", player.playerData.name);
        PlayerPrefs.SetInt("health", player.playerData.health);
        PlayerPrefs.SetInt("cash", player.playerData.cash);


    }
    public static PlayerData LoadData()
    {
        float x = PlayerPrefs.GetFloat("x");
        float y = PlayerPrefs.GetFloat("y");
        float z = PlayerPrefs.GetFloat("z");
        int health = PlayerPrefs.GetInt("health");
        int cash = PlayerPrefs.GetInt("cash");
        string name = PlayerPrefs.GetString("name");


        PlayerData playerData = new PlayerData(new Vector3(x, y, z), name, health, cash);
        return playerData;

    }
}