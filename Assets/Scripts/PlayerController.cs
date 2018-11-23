using UnityEngine;
using System.Collections;
using System.Reflection;
using System;
using UnityEditor;

public class PlayerController : MonoBehaviour {
    static MethodInfo _clearConsoleMethod;

	private Model model;
	private int playerRow, playerCol;
	public int[,] array;

    void Start () {
		ClearLogConsole();
		model = new Model(10, 10);
		this.array = model.array;
		FindPlayer(this.array);
		//model.DisplayArrayDebug();
		Debug.Log("Player Row: " + playerRow + "\nPlayer Col: " + playerCol);

	}
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.W))
		{
			MovePlayer("up");
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			MovePlayer("down");
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			MovePlayer("left");
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			MovePlayer("right");
		}	

	}

	private void MovePlayer(string direction)
	{
		for(int i = 0; i < array.GetLength(1); i++)
		{
            for (int j = 0; j < array.GetLength(0); j++)
            {
				if(array[i,j] == model.player)
				{
					if(direction == "right" && i > 0)
					{
						array[playerRow, playerCol] = 0;
						array[playerRow -1, playerCol] = model.player;
					}
					if(direction == "left" && i < array.GetLength(1)-1)
					{
						array[playerRow, playerCol] = 0;
						// Debug.Log(playerRow);
						array[playerRow +1, playerCol] = model.player;
					}
					if(direction == "up" && j > 0)
					{
						array[playerRow, playerCol] = 0;
						array[playerRow, playerCol -1] = model.player;
					}
					if(direction == "down" && j < array.GetLength(1)-1)
					{
						array[playerRow, playerCol] = 0;
						array[playerRow, playerCol + 1] = model.player;
					}
				}
            }
		}
        
		ClearLogConsole();
		FindPlayer(this.array);
		model.DisplayArrayDebug();
		Debug.Log("Player Row: " + playerRow + "\nPlayer Col: " + playerCol);
		
	}

	private void FindPlayer(int[,] array)
	{
		for(int i = 0; i < array.GetLength(1); i++)
		{
            for (int j = 0; j < array.GetLength(0); j++)
            {
				if(array[i,j] == 1)
				{
					playerRow = i;
					playerCol = j;
				}
            }
		}
	}


     static MethodInfo clearConsoleMethod {
         get {
             if (_clearConsoleMethod == null) {
                 Assembly assembly = Assembly.GetAssembly (typeof(SceneView));
                 Type logEntries = assembly.GetType ("UnityEditor.LogEntries");
                 _clearConsoleMethod = logEntries.GetMethod ("Clear");
             }
             return _clearConsoleMethod;
         }
     }
 
     public static void ClearLogConsole() {
         clearConsoleMethod.Invoke (new object (), null);
     }
}
