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

    public void showSpell(Model model) {
        int playerX = 0;
        int playerY = 0;

        for (int x = 0; x < model.array.GetLength(0); x++) {
            for (int y = 0; y < model.array.GetLength(1); y++) {
                Coordinates coord = new Coordinates(x, y);
                if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isCharacter() && model.getSquare(coord).getCharacter().isPlayable) {

                    playerX = x;
                    playerY = y;

                    if (!checkBounds(x, y, model.array.GetLength(0), model.array.GetLength(1))) {
                        print("You cannot do this spell, it is out of range");
                        return;
                    }
                }
            }
        }
        printSpell(playerX, playerY, model);
    }

    private void printSpell(int x, int y, Model model) {

        int quantity = range.getQuantity();

        if (range.getDirection() == "up") {
            for (int total = x - quantity; total < x; total++) {
                Coordinates coord = new Coordinates(total, y);
                if(model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                {
                    model.getSquare(coord).setSpellEffect(this);
                }
            }
        }

        else if (range.getDirection() == "down") {
            for (int total = x; total < x + quantity; total++) {
                Coordinates coord = new Coordinates(total + 1, y);
                if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                {
                    model.getSquare(coord).setSpellEffect(this);
                }
            }
        }

        else if (range.getDirection() == "left") {
            for (int total = y - quantity; total < y; total++) {
                Coordinates coord = new Coordinates(x, total);
                if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                {
                    model.getSquare(coord).setSpellEffect(this);
                }
            }
        }

        else if (range.getDirection() == "right") {
            for(int total = y; total < y + quantity; total++) {
                Coordinates coord = new Coordinates(x, total + 1);
                if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                {
                    model.getSquare(coord).setSpellEffect(this);
                }
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
