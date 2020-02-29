using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneShieldSpell :  CastableSpell
{
    GameObject Shield;

    public ArcaneShieldSpell(string SpellID, string SpellName, GameObject SpellPrefab) : base(SpellID, SpellName, SpellPrefab) {

    }

    public override void StartCastSpell(GameObject player) {
        Shield = MonoBehaviour.Instantiate(this.SpellPrefab, player.transform.position, player.transform.rotation) as GameObject;
        Shield.GetComponent<ArcaneShieldPrefabScript>().CastSpell(player);
    }

    public override void EndCastSpell(GameObject player)
    {
        Shield.GetComponent<ArcaneShieldPrefabScript>().EndCast();
    }
}
