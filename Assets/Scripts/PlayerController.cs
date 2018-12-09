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
        model.DisplayArrayDebug();
		
		Debug.Log("Player Row: " + playerRow + "\nPlayer Col: " + playerCol);

	}
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			MovePlayer(Directions.direction.Up);
		}
		if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			MovePlayer(Directions.direction.Down);
		}
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			MovePlayer(Directions.direction.Left);
		}
		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			MovePlayer(Directions.direction.Right);
		}
        if (Input.GetKeyDown(KeyCode.T))
        {
            Spell spell = new Spell("boom", 10, 10, Directions.direction.Right, 3);
            spell.showSpell(model);
        }


    }

	private void MovePlayer(Directions.direction direction)
	{
		for(int i = 0; i < array.GetLength(1); i++)
		{
            for (int j = 0; j < array.GetLength(0); j++)
            {
                Coordinates coord = new Coordinates(i, j);
				if(model.getSquare(coord).isOccupied() && model.getSquare(coord).isCharacter() && model.getSquare(coord).getCharacter().isPlayable)
				{
					if(direction == Directions.direction.Right && i > 0)
                    {
                        model.getSquare(new Coordinates(playerRow, playerCol)).setCharacter(null);
                        model.getSquare(new Coordinates(playerRow - 1, playerCol)).setCharacter(model.player);
                    }
					if(direction == Directions.direction.Left && i < array.GetLength(1)-1)
                    {
                        model.getSquare(new Coordinates(playerRow, playerCol)).setCharacter(null);
                        model.getSquare(new Coordinates(playerRow + 1, playerCol)).setCharacter(model.player);
                    }
					if(direction == Directions.direction.Up && j > 0)
					{
                        model.getSquare(new Coordinates(playerRow, playerCol)).setCharacter(null);
                        model.getSquare(new Coordinates(playerRow, playerCol - 1)).setCharacter(model.player);
                    }
					if(direction == Directions.direction.Down && j < array.GetLength(1)-1)
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
