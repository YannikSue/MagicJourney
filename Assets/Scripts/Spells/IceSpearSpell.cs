using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpearSpell : CastableSpell
{
    public IceSpearSpell(string SpellID, string SpellName, GameObject SpellPrefab) : base(SpellID, SpellName, SpellPrefab) {

    }

    public override void CastSpell(GameObject player) {
        GameObject iceSpear = MonoBehaviour.Instantiate(this.SpellPrefab, player.transform.position, player.transform.rotation) as GameObject;
        iceSpear.GetComponent<IceSpearPrefabScript>().CastSpell(player.transform.position);
    }
}
