using System;
using System.Collections;
using System.Collections.Generic;

public class Character : Entity {

	private bool isPlayable;
	//private Spell mySpell[];
	private int manaPoint;

	public Character (string name,Coordinates coord,int id,  bool isPlayable, int manaPoint, int hp): base(coord, name, id, hp){
        //TODO
        //add spell array        
		this.isPlayable = isPlayable;
		this.manaPoint = manaPoint;
	}

    public Character(string name, int x, int y, int id, bool isPlayable, int manaPoint, int hp): base(x,y, name, id, hp)
    {
		//TODO
		//add spell array
        
		this.isPlayable = isPlayable;
		this.manaPoint = manaPoint;
        
	}


    
    public int getManaPoint()
    {
        return this.manaPoint;
    }

    public void setManaPoint(int value)
    {
        this.manaPoint = value;
    }

    public void receiveDamage(int value)
    {
        if (value > 0)
        {
            if (!amIDead())
            {
                if (this.GetHp() - value > 0)
                {
                    this.SetHp(this.GetHp() - value);
                }else
                {
                    if (!this.isPlayable)
                    {
                        //monster die
                    }
                    else
                    {
                        //player die
                    }
                }
            }
            else
            {
                // I'm dead
            }
        }
        else
        {
            //value < 0 
        }
    }

    public void receiveHealth(int value)
    {
        if (value > 0)
        {
            if (!amIDead())
            {
                this.SetHp(this.GetHp() + value);
            }
            else
            {
                // I'm dead
            }
        }
        else
        {
            //value < 0 
        }
    }

    public bool amIDead()
    {
        if(this.GetHp() > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public string getFeature()
    {
        return "";
    }

    public void move(int x, int y)
    {
        if (x > 0 && y > 0)
        {
            this.coord.setX(x);
            this.coord.setY(y);
        }
        else
        {
            //illegal position
        }
    }

    public void move(Coordinates newCoord)
    {
        if(newCoord.getX() > 0 && newCoord.getY() > 0)
        {
            this.coord.setX(newCoord.getX());
            this.coord.setY(newCoord.getY());
        }
        else
        {
            //illegal position
        }
    }

}