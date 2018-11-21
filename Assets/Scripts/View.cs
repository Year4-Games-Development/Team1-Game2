using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class View : MonoBehaviour
{

    private int[,] map;
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


    private void Start()
    {
        width = Random.Range(5, 20);
        height = Random.Range(5, 20);
        map = new int[width, height];

        setBackground();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            setBackground();
        if (Input.GetMouseButtonDown(1))
            move();        
    }

    private void setBackground()
    {
        /////test
        width = Random.Range(5, 20);
        height = Random.Range(5, 20);
        map = new int[width, height];
        /////
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

        //////test
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                map[x, y] = 0;

        int px = Random.Range(0, width);
        int py = Random.Range(0, height);
        map[px, py] = 1;
        //////

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y] == 1)
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
            }
        }
    }
}
