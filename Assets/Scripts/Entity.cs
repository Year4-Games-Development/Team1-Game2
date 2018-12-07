using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Entity {
	protected Coordinates coord = new Coordinates();
    protected string name;
    protected int id;
    protected int hp; 
    public Entity()
    {

    }

	public Entity (Coordinates coord, string name, int id, int hp)
	{
        this.hp = hp;
        this.id = id;
        this.name = name;
		this.coord.setX(coord.getX());
		this.coord.setY(coord.getY());
	}

	public Entity (int x, int y, string name, int id, int hp)
	{
        this.hp = hp;
        this.id = id;
        this.name = name;
        this.coord.setX(x);
		this.coord.setY(y);
	}

    public int GetHp()
    {
        return this.hp;
    }

    public void SetHp(int value)
    {
        this.hp = value;
    }
}