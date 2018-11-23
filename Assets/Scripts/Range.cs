using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour {

    // Direction can be: up, down, left, right
    private string direction;

    private int quantity;

    public Range(string direction, int quantity) {
        this.direction = direction;
        this.quantity = quantity;
    }

    public string getDirection() {
        return direction;
    }

    public int getQuantity() {
        return quantity;
    }
}
