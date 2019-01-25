using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity {
	protected Coordinates coord = new Coordinates();
    protected string name;
    protected int id;
    private int hp;
    public int Hp {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if (hp > maxHp)
                hp = maxHp;
            else if (hp <= 0)
            {
                hp = 0;
                isDead = true;
            }
        }
    }
    protected int maxHp;
    public bool isDead { get; protected set;}


	public Entity (Coordinates coord, string name, int id, int hp)
	{
        this.hp = hp;
        this.maxHp = hp;
        this.id = id;
        this.name = name;
		this.coord.setX(coord.getX());
		this.coord.setY(coord.getY());
        isDead = false;
	}

	public Entity (int x, int y, string name, int id, int hp)
	{
        this.hp = hp;
        this.id = id;
        this.name = name;
        this.coord.setX(x);
		this.coord.setY(y);
        isDead = false;
	}

    public void receiveDamage(int value)
    {
        hp -= value;
        Debug.Log(hp + " : " + isDead);
            /*
        if (value > 0)
        {
            if (!amIDead())
            {
                if (this.GetHp() - value > 0)
                {
                    this.SetHp(this.GetHp() - value);
                }
                else
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
        }*/
    }
}