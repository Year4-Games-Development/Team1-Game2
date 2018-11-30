using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Item Class (Will be interface later) 
public class Item
{

    public int id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    //string use();

    public Item(int id, string name, string description)
    {
        this.id = id;
        Name = name;
        Description = description;
    }

}