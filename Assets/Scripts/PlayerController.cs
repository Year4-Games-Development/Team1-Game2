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

        //model.DisplayArrayDebug();		
		//Debug.Log("Player Row: " + playerRow + "\nPlayer Col: " + playerCol);

	}
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			MovePlayer(Orientation.Up);
            model.player.TheOrientation = Orientation.Up;
		}
		if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			MovePlayer(Orientation.Down);
		}
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			MovePlayer(Orientation.Left);
		}
		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			MovePlayer(Orientation.Right);
		}
        if (Input.GetKeyDown(KeyCode.T))
        {
            Spell spell = new Spell("Kamehaneha", 15, 20, array[playerRow,playerCol].getCharacter().TheOrientation, 7,0);
            spell.showSpell(model);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Spell spell = new Spell("Landslide", 8, 12, array[playerRow, playerCol].getCharacter().TheOrientation, 1,3);
            spell.showSpell(model);
        }
        /*if (Input.GetKeyDown(KeyCode.U))
        {
            Spell spell = new Spell("Tsunami", 10, 15, array[playerRow, playerCol].getCharacter().TheOrientation, 4,2);
            spell.showSpell(model);
        }*/
        if (Input.GetKeyDown(KeyCode.U))
        {
            Spell spell = new Spell("Tortuous Breath", 5, 7, array[playerRow, playerCol].getCharacter().TheOrientation, 1,0);
            spell.showSpell(model);
        }
    }

	private void MovePlayer(Orientation direction)
	{
		for(int i = 0; i < array.GetLength(1); i++)
		{
            for (int j = 0; j < array.GetLength(0); j++)
            {
                Coordinates coord = new Coordinates(i, j);
				if(model.getSquare(coord).isOccupied() && model.getSquare(coord).isCharacter() && model.getSquare(coord).getCharacter().isPlayable)
				{
					if(direction == Orientation.Right && i > 0)
                    {
                        model.getSquare(new Coordinates(playerRow, playerCol)).setCharacter(null);
                        model.getSquare(new Coordinates(playerRow - 1, playerCol)).setCharacter(model.player);
                    }
					if(direction == Orientation.Left && i < array.GetLength(1)-1)
                    {
                        model.getSquare(new Coordinates(playerRow, playerCol)).setCharacter(null);
                        model.getSquare(new Coordinates(playerRow + 1, playerCol)).setCharacter(model.player);
                    }
					if(direction == Orientation.Up && j > 0)
					{
                        model.getSquare(new Coordinates(playerRow, playerCol)).setCharacter(null);
                        model.getSquare(new Coordinates(playerRow, playerCol - 1)).setCharacter(model.player);
                    }
					if(direction == Orientation.Down && j < array.GetLength(1)-1)
					{
                        model.getSquare(new Coordinates(playerRow, playerCol)).setCharacter(null);
                        model.getSquare(new Coordinates(playerRow, playerCol + 1)).setCharacter(model.player);
                    }
				}
            }
		}
        
		ClearLogConsole();
		FindPlayer();
		//model.DisplayArrayDebug();
		//Debug.Log("Player Row: " + playerRow + "\nPlayer Col: " + playerCol);
		
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
