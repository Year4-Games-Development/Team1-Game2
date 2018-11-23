using System;
using System.Collections;
using System.Collections.Generic;

public class Entity {
	private Coordinates coord;

    public Entity()
    {

    }

	public Entity (Coordinates coord)
	{
		this.coord.setX(coord.getX());
		this.coord.setY(coord.getY());
	}

	public Entity (int x, int y)
	{
		this.coord.setX(x);
		this.coord.setY(y);
	}
}