using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Entity {

    public bool isDamagable { get; set; }
    public bool isInteractable { get; set; }
    //only 1 item for the moment
    private Item inventory;
    public Obstacle(Coordinates coord, bool isDamagable, bool isInteractable,  string name, int id, int hp, Item item) : base(coord, name, id, hp)
    {

        //chest is damagable and interactable
        //wall is not damagable or interactable
        this.isDamagable = isDamagable;
        this.isInteractable = isInteractable;
        this.inventory = item;
    }

    //open chest
    public Item Open()
    {
        if(!isInteractable)
        {
            return null;
        }
        Debug.Log(this.inventory.ToString());
        return this.inventory;
    }
}
