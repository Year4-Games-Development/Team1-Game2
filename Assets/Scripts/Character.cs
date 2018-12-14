using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation
{
    Up,
    Down,
    Right,
    Left
}


public class Character : Entity {

    public bool isPlayable { get; private set; }
    //private Spell mySpell[];
    private int manaPoint;
	public int ManaPoint
    {
        get
        {
            return manaPoint;
        }
        set
        {
            manaPoint = value;
            if (manaPoint > maxMana)
                manaPoint = maxMana;
            else if (manaPoint < 0)
                manaPoint = 0;
        }
    }
    private int maxMana = 10;
    public Orientation TheOrientation { get; set; }

	public Character (string name,Coordinates coord,int id,  bool isPlayable, int manaPoint, int hp): base(coord, name, id, hp){
        //TODO
        //add spell array        
		this.isPlayable = isPlayable;
		this.manaPoint = manaPoint;
        this.TheOrientation = Orientation.Up;
	}

    public Character(string name, int x, int y, int id, bool isPlayable, int manaPoint, int hp): base(x,y, name, id, hp)
    {
		//TODO
		//add spell array
        
		this.isPlayable = isPlayable;
		this.manaPoint = manaPoint;
        
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