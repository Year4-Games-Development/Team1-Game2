using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {
    private string name;
    private int amountOfDamage;
    private int mana;
    private Range range;

    public Spell(string name, int dmg, int mana, string direction, int quantity) {
        this.name = name;
        amountOfDamage = dmg;
        this.mana = mana;
        range = new Range(direction, quantity);
    }

    public void showSpell(int [,]map) {
        int playerX = 0;
        int playerY = 0;

        for (int x = 0; x < map.GetLength(0); x++) {
            for (int y = 0; y < map.GetLength(1); y++) {
                if (map[x,y] == 1) {

                    playerX = x;
                    playerY = y;

                    if (!checkBounds(x, y, map.GetLength(0), map.GetLength(1))) {
                        print("You cannot do this spell, it is out of range");
                        return;
                    }
                }
            }
        }
        printSpell(playerX, playerY, map);
    }

    private void printSpell(int x, int y, int [,]map) {

        int quantity = range.getQuantity();

        if (range.getDirection() == "up") {
            for (int total = x - quantity; total < x; total++) {
                map[total, y] = 8;
            }
        }

        else if (range.getDirection() == "down") {
            for (int total = x; total < x + quantity; total++) {
                map[total + 1, y] = 8;
            }
        }

        else if (range.getDirection() == "left") {
            for (int total = y - quantity; total < y; total++) {
                map[x, total] = 8;
            }
        }

        else if (range.getDirection() == "rigth") {
            for(int total = y; total < y + quantity; total++) {
                map[x, total + 1] = 8;
            }
        }       
    }

    /**
     * Check if when doing the spell, its amount goes over range.
     * Returns false if it goes over range, and returns true if it does not go over range.
     * 
     */
    private bool checkBounds(int x, int y, int maxX, int maxY) {

        int quantity = range.getQuantity();
        string direction = range.getDirection();

        if (direction == "up" && (x - quantity < 0) ||
            direction == "down" && (x + quantity >= maxX) ||
            direction == "left" && (y - quantity < 0) ||
            direction == "rigth" && (y + quantity >= maxY)) {

            return false;
        }

        else {
            return true;
        }
    }

    public string getName() {
        return name;
    }

    public int getAmountOfDamage() {
        return amountOfDamage;
    }

    public int getMana() {
        return mana;
    }

    public Range getRange() {
        return range;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
