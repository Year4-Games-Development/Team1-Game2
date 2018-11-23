using System;
using System.Collections;
using System.Collections.Generic;

public class Character : Entity{
	//TODO
	//add implements ICombat and IMovable

	private string name;
	private Coordinates coord;
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
}