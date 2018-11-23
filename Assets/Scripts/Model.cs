using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model {

	public int[,] array;
	public int x, y;

	public Model(int x, int y)
	{
		this.x = x;
		this.y = y;
		CreateMap(x,y);
	}

	private void CreateMap(int x, int y)
	{
		array = new int[x, y];

		for(int i = 0; i < x; i++) 
		{
			for(int j = 0; j < y; j++)
			{
				array[i,j] = 0;
			}
		}

		//player spawn in 5,5
		array[6,4] = 1;
	}

	public void DisplayArrayDebug()
	{
		

		for(int i = 0; i < x; i++) 
		{
			string s = "";
			for(int j = 0; j < y; j++)
			{
				s += "[" + array[i,j] + "]";
			}
			Debug.Log(s+"\n");
		}
	}
	
}
