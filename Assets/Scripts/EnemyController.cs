using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public PlayerController player;
    public List<Character> monsters;
    Square[,] array;
    public Model model;
    string direction = "left";
    private int monsterRow, monsterCol;

    // Use this for initialization
    void Start()
    {
   
        //this.array = player.array;
        Debug.Log("onche onche");
        monsters = new List<Character>();
        Debug.Log("model.array length" + model.array.GetLength(1));
        FindAllMonsters();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveMonters(int d, Square[,] array)
    {
        this.array = array;
        switch (d)
        {
            case 0:
                direction = "up";
                break;
            case 1:
                direction = "down";
                break;
            case 2:
                direction = "left";
                break;
            case 3:
                direction = "right";
                break;
            default:
                direction = "left";
                break;
        }
        Debug.Log("array (1) length: " + array.GetLength(1));
        for (int i = 0; i < array.GetLength(1); i++)
        {
            for (int j = 0; j < array.GetLength(0); j++)
            {
                Coordinates coord = new Coordinates(i, j);
                if (player.model.getSquare(coord).isOccupied() && player.model.getSquare(coord).isCharacter() && !player.model.getSquare(coord).getCharacter().isPlayable)
                {
                    if (direction == "right" && i > 0)
                    {
                        player.model.getSquare(new Coordinates(monsterRow, monsterCol)).setCharacter(null);
                        player.model.getSquare(new Coordinates(monsterRow - 1, monsterCol)).setCharacter(player.model.monster);
                    }
                    if (direction == "left" && i < array.GetLength(1) - 1)
                    {
                        player.model.getSquare(new Coordinates(monsterRow, monsterCol)).setCharacter(null);
                        player.model.getSquare(new Coordinates(monsterRow + 1, monsterCol)).setCharacter(player.model.monster);
                    }
                    if (direction == "up" && j > 0)
                    {
                        player.model.getSquare(new Coordinates(monsterRow, monsterCol)).setCharacter(null);
                        player.model.getSquare(new Coordinates(monsterRow, monsterCol - 1)).setCharacter(player.model.monster);
                    }
                    if (direction == "down" && j < array.GetLength(1) - 1)
                    {
                        player.model.getSquare(new Coordinates(monsterRow, monsterCol)).setCharacter(null);
                        player.model.getSquare(new Coordinates(monsterRow, monsterCol + 1)).setCharacter(player.model.monster);
                    }
                }
            }
        }

    }

    private void FindAllMonsters()
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            for (int j = 0; j < array.GetLength(0); j++)
            {
                if (array[i, j].isOccupied() && array[i, j].isCharacter() && !array[i, j].getCharacter().isPlayable)
                {
                    monsters.Add(array[i, j].getCharacter());
                    Debug.Log("monster found");
                    monsterRow = i;
                    monsterCol = j;
                }
            }
        }
    }
}
