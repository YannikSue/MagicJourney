using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBeamSpell : CastableSpell
{
    GameObject Beam;

    public EnergyBeamSpell(string SpellID, string SpellName, GameObject SpellPrefab) : base(SpellID, SpellName, SpellPrefab)
    {

    }

    public override void StartCastSpell(GameObject player)
    {
        this.CastTime = Time.time;
        Beam = MonoBehaviour.Instantiate(this.SpellPrefab, player.transform.position, player.transform.rotation) as GameObject;
        Beam.GetComponent<EnergyBeamPrefabScript>().CastSpell(player);
    }

    public override void EndCastSpell(GameObject player)
    {
        Beam.GetComponent<EnergyBeamPrefabScript>().EndCast();
        Debug.Log("Casted " + this.SpellID + " for " + (Time.time - this.CastTime) + " seconds");
        this.CastTime = 0f;
    }
}
