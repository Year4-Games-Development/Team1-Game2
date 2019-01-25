using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class View : MonoBehaviour
{
    //detect if we changed the map
    public int previousLvl = 0;
    public int currentLvl = 1 ;

    //use to get the map
    public PlayerController player;

    //current map
    private Square[,] map;
    private int width;
    private int height;

    //2 layouts of tile, the first is use for entities and the second for the background
    public Tilemap entityLayout;
    public Tilemap groundLayout;

    //entities sprites
    public Tile playerSprite;
    public Tile enemySprite;
    public Tile spellEfectTile;

    //ground sprites
    public Tile groundTile;
    public Tile groundTileVariation;
    public Tile upLeftBorderTile;
    public Tile upBorderTile;
    public Tile upRightBorderTile;
    public Tile leftBorderTile;
    public Tile rightBorderTile;
    public Tile downLeftBorderTile;
    public Tile downBorderTile;
    public Tile downRightBorderTile;
    


    private void Start()
    {
        map = player.array;
    }
    void Update()
    {
        //if we change the map
        if (previousLvl != currentLvl)
        {
            previousLvl = currentLvl;
            setBackground();
        }
            move();
    }

    private void setBackground()
    {
        map = player.array;
        //update current map size
        width = map.GetLength(1);
        height = map.GetLength(0);

        //clean the map
        groundLayout.ClearAllTiles();
        entityLayout.ClearAllTiles();

        //set ground tiles
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                Vector3Int coordinates = TileCoordinates(x, y);

                if (x == 0 && y == 0)//Up Right Border
                    groundLayout.SetTile(coordinates, upRightBorderTile);
                else if (x == 0 && y == height-1)//Down Right Border
                    groundLayout.SetTile(coordinates, downRightBorderTile);
                else if (x == 0)//Right Border
                    groundLayout.SetTile(coordinates, rightBorderTile);
                else if (x == width-1 && y == 0)//Up Left Border
                    groundLayout.SetTile(coordinates, upLeftBorderTile);
                else if (x == width-1 && y == height-1)//Down Left Border
                    groundLayout.SetTile(coordinates, downLeftBorderTile);
                else if (x == width-1)//Left Border
                    groundLayout.SetTile(coordinates, leftBorderTile);
                else if (y == 0)//Up Border
                    groundLayout.SetTile(coordinates, upBorderTile);
                else if (y == height-1)// Down Border
                    groundLayout.SetTile(coordinates, downBorderTile);
                else//normal ground (not a border)
                {
                    int rand = Random.Range(0, 10);//1/10 chance to be a variate ground
                    switch (rand)
                    {
                        case 1://variation
                            groundLayout.SetTile(coordinates, groundTileVariation);
                            break;
                        default:
                            groundLayout.SetTile(coordinates, groundTile);
                            break;
                    }
                }
            }
    }

    

    private void move()
    {
        //reset positions
        entityLayout.ClearAllTiles();

        //set entites tiles
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                Vector3Int coordinates = TileCoordinates(x, y);
                //player tile
                if (map[x, y].isOccupied() && map[x, y].isCharacter() && map[x, y].getCharacter().isPlayable)
                    entityLayout.SetTile(coordinates, playerSprite);
                //monster tile
                if (map[x, y].isOccupied() && map[x, y].isCharacter() && !map[x, y].getCharacter().isPlayable)
                    entityLayout.SetTile(coordinates, enemySprite);
                //spell effect tile
                if (map[x, y].haveSpellEffect())
                    entityLayout.SetTile(coordinates, spellEfectTile);
            }
    }

    //create the vector for tile set
    private Vector3Int TileCoordinates(int x, int y)
    {
        return new Vector3Int(-x + width/2, -y + height/2, 0);
    }

}
