using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class View : MonoBehaviour
{
    
    public int previousLvl = 0;
    public int currentLvl = 1 ;

    public PlayerController player;

    private Square[,] map;
    private int width;
    private int height;

    public Tilemap topMap;
    public Tilemap botMap;

    public Tile topTile;

    public Tile botTile0;
    public Tile botTile1;
    public Tile botBorderTileUL;
    public Tile botBorderTileU;
    public Tile botBorderTileUR;
    public Tile botBorderTileL;
    public Tile botBorderTileR;
    public Tile botBorderTileDL;
    public Tile botBorderTileD;
    public Tile botBorderTileDR;

    public Tile spellEffect;


    private void Start()
    {
        map = player.array;
    }
    void Update()
    {
        if (previousLvl != currentLvl)
        {
            previousLvl = currentLvl;
            setBackground();
        }
            
        //if (Input.GetMouseButtonDown(1))
            move();
    }

    private void setBackground()
    {
        map = player.array;
        width = map.GetLength(1);
        height = map.GetLength(0);
        Debug.Log(width);
        botMap.ClearAllTiles();
        topMap.ClearAllTiles();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 && y == 0)
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botBorderTileUR);
                else if (x == 0 && y == height-1)
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botBorderTileDR);
                else if (x == 0)
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botBorderTileR);
                else if (x == width-1 && y == 0)
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botBorderTileUL);
                else if (x == width-1 && y == height-1)
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botBorderTileDL);
                else if (x == width-1)
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botBorderTileL);
                else if (y == 0)
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botBorderTileU);
                else if (y == height-1)
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botBorderTileD);
                else
                {
                    int rand = Random.Range(0, 10);
                    switch (rand)
                    {
                        case 1:
                            botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile1);
                            break;
                        default:
                            botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile0);
                            break;
                    }
                }
            }
        }
    }

    

    private void move()
    {
        topMap.ClearAllTiles();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y].isOccupied() && map[x, y].isCharacter() && map[x, y].getCharacter().isPlayable)
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
                if (map[x, y].haveSpellEffect())
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), spellEffect);
            }
        }
    }
}
