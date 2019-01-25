using System;
using System.Collections;
using System.Collections.Generic;

public class Coordinates{
	private int x;
	private int y;

    public Coordinates()
    {

    }

	public Coordinates(int x, int y){
		this.x = x;
		this.y = y;
	}

	public int getX(){
		return this.x;
	}

	public void setX(int value){
		this.x = value;
	}

	public int getY(){
		return this.y;
	}

	public void setY(int value){
		this.y = value;
	}
}