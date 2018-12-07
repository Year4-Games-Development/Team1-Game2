using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour {

    // Direction can be: up, down, left, right
    private Orientation direction;

    private int quantityX;
    private int quantityY;

    public Range(Orientation direction, int quantityX, int quantityY) {
        this.direction = direction;
        this.quantityX = quantityX;
        this.quantityY = quantityY;
    }

    public Orientation getDirection() {
        return direction;
    }

    public int getQuantityX() {
        return quantityX;
    }

    public int getQuantityY()
    {
        return quantityY;
    }
}
