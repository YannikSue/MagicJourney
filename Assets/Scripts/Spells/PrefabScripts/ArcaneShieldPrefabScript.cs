using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneShieldPrefabScript : MonoBehaviour
{
    float spellDuration = 5f;

    GameObject Player;

    public void CastSpell(GameObject player)
    {
        this.Player = player;
        Destroy(gameObject, spellDuration);
    }

    void Update()
    {
        gameObject.transform.position = this.Player.transform.position;
    }
}
