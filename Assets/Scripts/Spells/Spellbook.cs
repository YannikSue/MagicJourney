﻿using System.Collections.Generic;
using UnityEngine;

public class Spellbook
{
    GameObject Player;

    public List<CastableSpell> AllSpells = new List<CastableSpell>();

    CastableSpell SelectedSpell;

    public Spellbook(GameObject player)
    {
        this.Player = player;

        // TODO add spells to Spellbook in a different Way, not just in plain code, maybe by using file system? maybe static class of Spellbook?
        AllSpells.Add(new FireBallSpell("fireballSpell", "Fireball", Resources.Load("Fireball/FireBallPrefab") as GameObject));
        AllSpells.Add(new IceSpearSpell("iceSpearSpell", "Ice Spear", Resources.Load("IceSpear/IceSpearPrefab") as GameObject));
        AllSpells.Add(new ArcaneShieldSpell("shieldSpell", "Arcane Shield", Resources.Load("ArcaneShieldPrefab") as GameObject));
        AllSpells.Add(new EnergyBeamSpell("energyBeamSpell", "Energy Beam", Resources.Load("EnergyBeamPrefab") as GameObject));

        LearnSpell(AllSpells[0].GetID());
        LearnSpell(AllSpells[1].GetID());
        LearnSpell(AllSpells[2].GetID());
        LearnSpell(AllSpells[3].GetID());

        SelectSpell(AllSpells[0].GetID());
    }

    public void StartCastSpell()
    {
        SelectedSpell.StartCastSpell(this.Player);
    }

    public void EndCastSpell()
    {
        SelectedSpell.EndCastSpell(this.Player);
    }

    public void SelectSpell(string id)
    {

        // TODO if spell id doesn't exist -> throw exception
        if (SelectedSpell == null || !id.Equals(SelectedSpell.GetID()))
        {
            foreach (CastableSpell spell in AllSpells)
            {
                if (id.Equals(spell.GetID()) && spell.HasBeenLearned())
                {
                    this.SelectedSpell = spell;
                }
            }
        }
    }

    public void LearnSpell(string id)
    {

        // TODO if spell id doesn't exist -> throw exception
        foreach (CastableSpell spell in AllSpells)
        {
            if (spell.GetID().Equals(id))
            {
                spell.LearnSpell();
            }
        }
    }
}
