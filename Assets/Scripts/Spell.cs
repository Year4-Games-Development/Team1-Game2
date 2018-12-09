using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell {
    private string name;
    private int amountOfDamage;
    private int mana;
    private Range range;

    public Spell(string name, int dmg, int mana, Orientation direction, int quantityX, int quantityY) {
        this.name = name;
        amountOfDamage = dmg;
        this.mana = mana;
        range = new Range(direction, quantityX, quantityY);
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
                        Debug.Log("You cannot do this spell, it is out of range");
                        return;
                    }
                }
            }
        }
        printSpell(playerX, playerY, model);
    }

    private void printSpell(int x, int y, Model model) {

        int quantityX = range.getQuantityX();
        int quantityY = range.getQuantityY();

if (range.getDirection() == Orientation.Up) {
            for (int total = x - quantityX; total < x; total++) {
                if(quantityY != 0)
                {
                    for (int i = -((quantityY-1)/2); i < ((quantityY - 1)/ 2)+1 ; i++)
                    {
                        Coordinates coord = new Coordinates(total, y+i);
                        if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                        {
                            model.getSquare(coord).setSpellEffect(this);
                        }
                    }
                }
                else
                {
                    Coordinates coord = new Coordinates(total, y);
                    if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                    {
                        model.getSquare(coord).setSpellEffect(this);
                    }
                }
            }
        }

 else if (range.getDirection() == Orientation.Down) {
            for (int total = x; total < x + quantityX; total++) {
                if (quantityY != 0)
                {
                    for (int i = -((quantityY - 1) / 2); i < ((quantityY - 1) / 2) + 1; i++)
                    {
                        Coordinates coord = new Coordinates(total + 1, y+i);
                        if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                        {
                            model.getSquare(coord).setSpellEffect(this);
                        }
                    }
                }
                else
                {
                    Coordinates coord = new Coordinates(total + 1, y);
                    if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                    {
                        model.getSquare(coord).setSpellEffect(this);
                    }
                }
                
            }
        }

else if (range.getDirection() == Orientation.Left) {
            for (int total = y - quantityX; total < y; total++)
            {
                if (quantityY != 0)
                {
                    for (int i = -((quantityY - 1) / 2); i < ((quantityY - 1) / 2) + 1; i++)
                    {
                        Coordinates coord = new Coordinates(x+i, total);
                        if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                        {
                            model.getSquare(coord).setSpellEffect(this);
                        }
                    }
                }
                else
                {
                    Coordinates coord = new Coordinates(x, total);
                    if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                    {
                        model.getSquare(coord).setSpellEffect(this);
                    }
                }
            }
        }
        else if (range.getDirection() == Orientation.Right) {
            for(int total = y; total < y + quantityX; total++)
            {
                if (quantityY != 0)
                {
                    for (int i = -((quantityY - 1) / 2); i < ((quantityY - 1) / 2) + 1; i++)
                    {
                        Coordinates coord = new Coordinates(x + i, total + 1);
                        if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                        {
                            model.getSquare(coord).setSpellEffect(this);
                        }
                    }
                }
                else
                {
                    Coordinates coord = new Coordinates(x, total + 1);
                    if (model.getSquare(coord).isOccupied() && model.getSquare(coord).isObstacle() && model.getSquare(coord).getObstacle().isDamagable)
                    {
                        model.getSquare(coord).setSpellEffect(this);
                    }
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
int quantityX = range.getQuantityX();
        int quantityY = range.getQuantityY();
        Orientation direction = range.getDirection();

        if (direction == Orientation.Up && (x - quantityX < 0) && ((y + (quantityY+1/2) < 0) || (y + (quantityY + 1 / 2) >= maxY)) ||
            direction == Orientation.Down && (x + quantityX >= maxX) && ((y + (quantityY + 1 / 2) < 0) || (y + (quantityY + 1 / 2) >= maxY)) ||
            direction == Orientation.Left && (y - quantityX < 0) && ((x + (quantityY + 1 / 2) < 0) || (y + (quantityY + 1 / 2) >= maxX)) ||
            direction == Orientation.Right && (y + quantityX >= maxY) && ((x + (quantityY + 1 / 2) < 0) || (y + (quantityY + 1 / 2) >= maxX))) {

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
