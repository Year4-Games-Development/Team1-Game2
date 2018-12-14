using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{

    public Square[,] array;
    public Spell[] spellArray;
    public int x, y;
    public Character player; //modify player in entity
    public Character monster; //modify monster in entity


    //TODO
    // Modify array int in array Square 
    // Add function for create monster

    public Model(int x, int y)
    {
        CreateMap(x, y);
        this.player = new Character("Player", new Coordinates(5, 5), 1, true, 20, 20);
        setOccupationByCharacter(new Coordinates(5, 5), this.player);
        this.x = x;
        this.y = y;
        initializeBoard();
        DisplayArrayDebug();
    }

    private void initializeBoard()
    {
//        CreateObstacles(1);
//        CreateMonsters(1);
    }


    private void CreateObstacles(int numObstacles)
    {
        int difficultyLvl = 2;
        int nbrObstacle = Random.Range(1 * difficultyLvl, 3 * difficultyLvl);

        /*for (int i = 0; i < nbrObstacle; i++)
        {
            Coordinates obstacleCoord;
            do
            {
                obstacleCoord = new Coordinates(Random.Range(0, this.x), Random.Range(0, this.y));
            }
            while (getSquare(monsterCoord).isOccupied());

            Character monster = new Character("Mob" + i, monsterCoord, false, 10, 10);
            setOccupation(monsterCoord, monster);
        }*/

    }

    private void CreateMonsters(int numMonsters)
    {
        for (int i = 0; i < numMonsters; i++)
        {
            Coordinates monsterCoord;
            do
            {
                monsterCoord = new Coordinates(Random.Range(0, this.x), Random.Range(0, this.y));
            }
            while (getSquare(monsterCoord).isOccupied());

            monster = new Character("Mob" + i, monsterCoord, 10 + i, false, 10, 10);
            setOccupationByCharacter(monsterCoord, monster);
        }
    }

    private void CreateMap(int x, int y)
    {
        array = new Square[x,y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                array[i, j] = new Square();
            }
        }

        //player spawn in 5,5
        //array[5,5] = player;

    }

    private void setOccupationByCharacter(Coordinates coord, Character entity)
    {
        //check if coord is no "illegal"
        if (entity == null)
        {
            getSquare(coord).setCharacter(null);
        }
        else
        {
            getSquare(coord).setCharacter(entity);
        }
    }

    private void setOccupationByObstacle(Coordinates coord, Obstacle entity)
    {
        //check if coord is no "illegal"
        if (entity == null)
        {
            getSquare(coord).setObstacle(null);
        }
        else
        {
            getSquare(coord).setObstacle(entity);
        }
    }

    public Square getSquare(Coordinates coord)
    {

        return array[coord.getX(), coord.getY()];
    }

    public void DisplayArrayDebug()
    {

        for (int i = 0; i < x; i++)
        {
            string s = "";
            for (int j = 0; j < y; j++)
            {
                //if (PlayerInIndex(i, j))
                //{
                //    s += "[" + this.player + "]";

                //}
                s += "["  + GetCharRepresentation(i, j) + "]";
            }
            Debug.Log(s + "\n");
        }
    }

    public int GetBoardWidth()
    {
        return array.GetLength(1);

    }

    public int GetBoardHeight()
    {
        return array.GetLength(0);

    }

    private bool PlayerInIndex(int row, int col)
    {
        if (array[row, col].isCharacter() && array[row, col].getCharacter().isPlayable)
            return true;
        return false;
    }

    private bool NothingInIndex(int row, int col)
    {
        if (!array[row, col].isCharacter() || !array[row, col].getCharacter().isPlayable)
            return true;
        return false;
    }

    private bool MonsterInIndex(int row, int col)
    {
        if (array[row, col].isCharacter() && !array[row, col].getCharacter().isPlayable)
            return true;
        return false;
    }

    private CharRepresentation GetCharRepresentation(int row, int col)
    {
        if(PlayerInIndex(row, col))
        {
            return CharRepresentation.P;
        }

        else if(MonsterInIndex(row,col))
        {
            return CharRepresentation.M;
        }
        else return CharRepresentation._;
    }

    public enum CharRepresentation
    {
        P, //player
        _, //background
        M, //monster
        XX //monster & player
    }

}
