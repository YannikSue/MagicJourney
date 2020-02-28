using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneShieldSpell :  CastableSpell
{
    public ArcaneShieldSpell(string SpellID, string SpellName, GameObject SpellPrefab) : base(SpellID, SpellName, SpellPrefab) {

    }

    public override void CastSpell(GameObject player) {
        GameObject shield = MonoBehaviour.Instantiate(this.SpellPrefab, player.transform.position, player.transform.rotation) as GameObject;
        shield.GetComponent<ArcaneShieldPrefabScript>().CastSpell(player);
    }
}
