using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpell : CastableSpell
{
    public FireBallSpell(string SpellID, string SpellName, GameObject SpellPrefab) : base(SpellID, SpellName, SpellPrefab) {

    }

    public override void StartCastSpell(GameObject player) {
        GameObject fireball = MonoBehaviour.Instantiate(this.SpellPrefab, player.transform.position, player.transform.rotation) as GameObject;
        fireball.GetComponent<FireBallPrefabScript>().CastSpell(player.transform.position);
    }

    public override void EndCastSpell(GameObject player)
    {
        
    }
}
