using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook
{
    GameObject Player;
    List<CastableSpell> AllSpells = new List<CastableSpell>();
    public Spellbook(GameObject player){
        this.Player = player;

        // TODO add spells to Spellbook in a different Way, not just in plain code, maybe by using file system?
        AllSpells.Add(new FireBallSpell("fireballSpell", "Fireball", Resources.Load("FireBallSpell") as GameObject));
        AllSpells.Add(new FireBallSpell("iceSpearSpell", "Ice Spear", Resources.Load("FireBallSpell") as GameObject));
        AllSpells.Add(new FireBallSpell("shieldSpell", "Arcane Shield", Resources.Load("FireBallSpell") as GameObject));

        LearnSpell(AllSpells[0].GetID());
        SelectSpell(AllSpells[0].GetID());
    }

    public void CastSpell(){
        foreach(CastableSpell spell in AllSpells) {
            if(spell.IsSelected() && spell.HasBeenLearned()) {
                spell.TestCast();
                break;
            }
        }
    }

    public void SelectSpell(string id) {

        // TODO check if spell id exists in AllSpells -> if not throw exception
        foreach( CastableSpell spell in AllSpells ){
            if(spell.GetID().Equals(id)){
                spell.SelectSpell(true);
            } else {
                spell.SelectSpell(false);
            }
        }
    }

    public void LearnSpell(string id){

        // TODO if spell id doesn't exist -> throw exception
        foreach( CastableSpell spell in AllSpells ){
            if(spell.GetID().Equals(id)){
                spell.LearnSpell();
            }
        }
    }
}
