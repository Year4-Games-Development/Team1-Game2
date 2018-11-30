﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{

    private int size;

    public List<Item> items;

    public Inventory(int size)
    {
        this.size = size;
        items = new List<Item>();
    }

    public Item GetItem(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (name == items[i].Name)

            {
                return items[i];
            }
        }
        return null;

    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }


    public void Drop(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (item.id == items[i].id)

            {
                items.RemoveAt(i);
                return;
            }
        }
    }

    public string ShowInventory()
    {
        if (items.Count < 1)
            return "Your inverntory is empty";

        string result = "";

        for (int i = 0; i < items.Count; i++)
        {
            result += items[i].Name + "\n";
        }
        return result;
    }


    public bool isInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
            if (item.Name == items[i].Name)
                return true;
        return false;
    }






}
