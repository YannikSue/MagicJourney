using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CastableSpell
{
    // a unique id for the spell
    protected string SpellID;

    // the display name of the spell
    protected string SpellName;

    // the prefab asscoiated with the spell
    protected GameObject SpellPrefab;

    // has the player learned this spell
    protected bool Learned = false;

    // used when a spell has a cast time or is a continious spell
    protected float CastTime = 0f;

    public CastableSpell(string SpellID, string SpellName, GameObject SpellPrefab) {
        this.SpellID = SpellID;
        this.SpellName = SpellName;
        this.SpellPrefab = SpellPrefab;
    }

    // Fires when the player presses the fire button
    public abstract void StartCastSpell(GameObject player);

    // Fires when the player releases the fire button after pressing it
    public abstract void EndCastSpell(GameObject player);

    // Used in testing new spells
    public void TestCast(){
        Debug.Log("Cast " + SpellName);
    }

    // Leanrs the spell of the given ID
    public void LearnSpell(){

        if(this.Learned) {
            Debug.LogError("Spell: " + this.SpellID + " has been learned more than once");
        }

        this.Learned = true;
    }

    public bool HasBeenLearned() {
        return Learned;
    }

    public string GetID(){
        return SpellID;
    }

    public string GetSpellName()
    {
        return this.SpellName;
    }
}
