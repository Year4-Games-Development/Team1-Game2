using System;
using System.Collections;
using System.Collections.Generic;

public class Character : Entity {

	private string name;
    private Coordinates coord = new Coordinates();
	private bool isPlayable;
	//private Spell mySpell[];
	private int manaPoint;
	private int lifePoint;

	public Character (string name,Coordinates coord, bool isPlayable, int manaPoint, int lifePoint){
		//TODO
		//add spell array

		this.name = name;
		this.coord.setX(coord.getX());
		this.coord.setY(coord.getY());
		this.isPlayable = isPlayable;
		this.manaPoint = manaPoint;
		this.lifePoint = lifePoint;
	}

	public Character (string name,int x, int y, bool isPlayable, int manaPoint, int lifePoint){
		//TODO
		//add spell array

		this.name = name;
		this.coord.setX(x);
		this.coord.setY(y);
		this.isPlayable = isPlayable;
		this.manaPoint = manaPoint;
		this.lifePoint = lifePoint;
        
	}

    public int getLifePoint()
    {
        return this.lifePoint;
    }

    public void setLifePoint(int value)
    {
        this.lifePoint = value;
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
                if (this.getLifePoint() - value > 0)
                {
                    this.setLifePoint(this.getLifePoint() - value);
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
                this.setLifePoint(this.getLifePoint() + value);
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
        if(this.getLifePoint() > 0)
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