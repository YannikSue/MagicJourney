using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneShieldPrefabScript : MonoBehaviour
{
    GameObject Player;

    public void CastSpell(GameObject player)
    {
        this.Player = player;
    }

    public void EndCast()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        gameObject.transform.position = this.Player.transform.position;
    }
}
