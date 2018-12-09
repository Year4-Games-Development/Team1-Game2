using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square  {
    private Obstacle obstacle; //player or monster in this case
    private Character character;
    private Spell spellEffect;
    //TODO 
    
    public Square()
    {
        this.character = null;
        this.spellEffect = null;
    }
        
    public bool isOccupied()
    {
        return getCharacter() != null || getObstacle() != null;
 
    }

    public bool isCharacter()
    {
        if (this.character == null)
            return false;
        else
            return true;
    }

    public bool isObstacle()
    {
        if (this.obstacle == null)
            return false;
        else
            return true;
    }

    public bool haveSpellEffect()
    {
        if (this.spellEffect == null)
            return false;
        else
            return true;
    }

    public Character getCharacter()
    {
        return this.character;
    }

    public void setCharacter(Character character)
    {
        this.character = character;
    }

    public void setObstacle(Obstacle obstacle)
    {
        this.obstacle = obstacle;
    }

    public Obstacle getObstacle()
    {
        return this.obstacle;
    }

    public void setSpellEffect(Spell spell)
    {
        this.spellEffect = spell;
    }

    public Spell getSpellEffect()
    {
        return this.spellEffect;
    }
}
