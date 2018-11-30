using UnityEngine;
using System.Collections;
using System.Reflection;
using System;
using UnityEditor;

public class PlayerController : MonoBehaviour {
    static MethodInfo _clearConsoleMethod;

	private Model model;
	private int playerRow, playerCol;
	public Square[,] array;

    void Start () {
		// ClearLogConsole();
		model = new Model(10, 10);
		this.array = model.array;
		FindPlayer();
		// model.DisplayArrayDebug();
		
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
        if (Input.GetKeyDown(KeyCode.T))
        {
            Spell spell = new Spell("boom", 10, 10, "right", 3);
            spell.showSpell(model);
        }


    }

	private void MovePlayer(string direction)
	{
		for(int i = 0; i < array.GetLength(1); i++)
		{
            for (int j = 0; j < array.GetLength(0); j++)
            {
                Coordinates coord = new Coordinates(i, j);
				if(model.getSquare(coord).isOccupied() && model.getSquare(coord).isCharacter() && model.getSquare(coord).getCharacter().isPlayable)
				{
					if(direction == "right" && i > 0)
                    {
                        model.getSquare(new Coordinates(playerRow, playerCol)).setCharacter(null);
                        model.getSquare(new Coordinates(playerRow - 1, playerCol)).setCharacter(model.player);
                    }
					if(direction == "left" && i < array.GetLength(1)-1)
                    {
                        model.getSquare(new Coordinates(playerRow, playerCol)).setCharacter(null);
                        model.getSquare(new Coordinates(playerRow + 1, playerCol)).setCharacter(model.player);
                    }
					if(direction == "up" && j > 0)
					{
                        model.getSquare(new Coordinates(playerRow, playerCol)).setCharacter(null);
                        model.getSquare(new Coordinates(playerRow, playerCol - 1)).setCharacter(model.player);
                    }
					if(direction == "down" && j < array.GetLength(1)-1)
					{
                        model.getSquare(new Coordinates(playerRow, playerCol)).setCharacter(null);
                        model.getSquare(new Coordinates(playerRow, playerCol + 1)).setCharacter(model.player);
                    }
				}
            }
		}
        
		ClearLogConsole();
		FindPlayer();
		model.DisplayArrayDebug();
		Debug.Log("Player Row: " + playerRow + "\nPlayer Col: " + playerCol);
		
	}

	private void FindPlayer()
	{
		for(int i = 0; i < array.GetLength(1); i++)
		{
            for (int j = 0; j < array.GetLength(0); j++)
            {
                Coordinates coord = new Coordinates(i, j);
				if(model.getSquare(coord).isOccupied() && model.getSquare(coord).isCharacter() && model.getSquare(coord).getCharacter().isPlayable)
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
