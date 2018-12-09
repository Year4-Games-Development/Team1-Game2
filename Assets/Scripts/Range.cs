using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour {

    // Direction can be: up, down, left, right
    private Directions.direction direction;

    private int quantity;

    public Range(Directions.direction direction, int quantity) {
        this.direction = direction;
        this.quantity = quantity;
    }

    public Directions.direction getDirection() {
        return direction;
    }

    public int getQuantity() {
        return quantity;
    }
}
