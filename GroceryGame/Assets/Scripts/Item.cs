using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    public string type;
    public float price;

    public Item(string itemName, string itemType, float itemPrice){
        this.name = itemName;
        this.type = itemType;
        this.price = itemPrice;
    }

    public string getName(){
        return name;
    }

    public string getType(){
        return type;
    }

    public float getPrice(){
        return price;
    }

    public void printInfo(){
        Debug.Log("--------------------\nItem Name: " + this.name + "\nItem Price: " + this.price + "\nItem Type: " + this.type + "\n--------------------");
    }
}
