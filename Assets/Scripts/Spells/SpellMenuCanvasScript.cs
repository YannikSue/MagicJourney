using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellMenuCanvasScript : MonoBehaviour
{
    public GameObject Player;

    public void UpdateLearnedSpells() {
       foreach (Transform child in transform)
        {
            Button btn = child.GetComponent<Button>();

            if(btn != null)
            {
                foreach (CastableSpell spell in Player.GetComponent<Player>().Spellbook.AllSpells)
                {
                    if (btn.name.Equals(spell.GetID()))
                    {
                        btn.interactable = spell.HasBeenLearned();
                    }
                }
            }
        }
    }

    public void ChangeSelectedSpellOfPlayer(string spellId){
        Player.GetComponent<Player>().Spellbook.SelectSpell(spellId);
    }
}