using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CastableSpell
{
    string SpellID;
    string SpellName;
    GameObject SpellPrefab;
    bool Learned = false;
    public CastableSpell(string SpellID, string SpellName, GameObject SpellPrefab) {
        this.SpellID = SpellID;
        this.SpellName = SpellName;
        this.SpellPrefab = SpellPrefab;
    }

    public abstract void CastSpell(GameObject player);

    public void TestCast(){
        Debug.Log("Cast " + SpellName);
    }

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
}
