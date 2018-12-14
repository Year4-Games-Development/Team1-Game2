using UnityEngine;
using System.Collections;
using System.Reflection;
using System;
using UnityEditor;
public class PlayerControllerNonMono {
    static MethodInfo _clearConsoleMethod;

	private Model model;
    public int playerRow, playerCol;
    private int monsterRow, monsterCol;
    
	public Square[,] array;
    public void MyStart () {
		// ClearLogConsole();
		model = new Model(10, 10);
        this.array = model.array;
		FindPlayer();
        FindMonster();
        model.CreatePlayer();
        //model.DisplayArrayDebug();		
		//Debug.Log("Player Row: " + playerRow + "\nPlayer Col: " + playerCol);

	}
	
	public void MyUpdate () {

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            MovePlayer(Orientation.Up);

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			MovePlayer(Orientation.Down);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			MovePlayer(Orientation.Left);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			MovePlayer(Orientation.Right);

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

        if (Input.anyKeyDown)
        {
            //MoveMonster(UnityEngine.Random.Range(0, 4));
        }

    }

	public void MovePlayer(Orientation direction)
	{
        model.player.TheOrientation = direction;

        Coordinates coord = new Coordinates(playerRow, playerCol);

        if (!TryToMovePlayer(coord, direction))
        {
            // beep to user since not able to move
        }

        ClearLogConsole();
        FindPlayer();
        model.DisplayArrayDebug();
    
    }

    public bool AttemptToMoveOffBoard(Orientation direction)
    {
        // each test returns TRUE
        if (direction == Orientation.Right && playerCol == model.GetBoardWidth()-1) return true;
        if (direction == Orientation.Left && playerCol < 1) return true;
        if (direction == Orientation.Up && playerRow < 1) return true;
        if (direction == Orientation.Down && playerRow == model.GetBoardHeight()-1) return true;

        // if get to end - not trying to move off board
        return false;
    }


    public bool TryToMovePlayer(Coordinates coord, Orientation direction)
    {
        Coordinates destinationLocation = coord;

        if (AttemptToMoveOffBoard(direction))
            return false;

        switch(direction)
        {
        case Orientation.Right:
            destinationLocation = new Coordinates(playerRow, playerCol + 1);
            break;
        case Orientation.Left:
            destinationLocation = new Coordinates(playerRow, playerCol - 1);
            break;
        case Orientation.Up:
                destinationLocation = new Coordinates(playerRow - 1, playerCol);
                break;
        case Orientation.Down:
            destinationLocation = new Coordinates(playerRow + 1, playerCol);
            break;
        }

        //Debug.Log("about to test isOccupied");


        if (!model.getSquare(destinationLocation).isOccupied())
        {
            Debug.Log("NOT OCCUPIED - TRYING TO MOVE PLAYER IN MODEL");

            // remove player from old square
            model.getSquare(coord).setCharacter(null);

            // set square in new location
            model.getSquare(destinationLocation).setCharacter(model.player);

            return true;
        }
        //if its occupied by a monster, player takes damage
        else if(model.MonsterInIndex(destinationLocation.getX(), destinationLocation.getY()))
        {
            model.player.receiveDamage(5);
        }

        return false;
    }

 
    public void FindPlayer()
	{
		for(int i = 0; i < array.GetLength(1); i++)
		{
            for (int j = 0; j < array.GetLength(0); j++)
            {
                Coordinates coord = new Coordinates(i, j);
                if (model.PlayerInIndex(i, j))
				{
					playerRow = i;
					playerCol = j;
				}
            }
		}
	}

    private void FindMonster()
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            for (int j = 0; j < array.GetLength(0); j++)
            {
                Coordinates coord = new Coordinates(i, j);
                if (model.MonsterInIndex(i, j))
                {
                    monsterRow = i;
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


    private void SetPlayerRow(int row)
    {
        this.playerRow = row;
    }

    private int GetPlayerRow()
    {
        return this.playerRow;
    }

    private void SetMonsterrRow(int row)
    {
        this.monsterRow = row;
    }

    private int GetMonsterRow()
    {
        return this.monsterRow;
    }

    private void SetPlayerCol(int col)
    {
        this.playerRow = col;
    }

    private int GetPlayerCol()
    {
        return this.playerCol;
    }

    private void SetMonsterrCol(int col)
    {
        this.monsterRow = col;
    }

    private int GetMonsterCol()
    {
        return this.monsterCol;
    }


}
