using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    private string customerName; //The customer's name to refer to in the game
    private Order customerOrder;

    public Customer(string name){
        this.customerName = name;
        this.customerOrder = new Order(); //Creates new order, assigns the order to the customer list
    }

    public void printCustomerOrder(){
        Debug.Log(customerName + " has ordered: ");
        foreach(Item item in customerOrder.getOrder()){
            Debug.Log(item.getName());
        }
    }

    public Item[] getOrder(){
        return customerOrder.getOrder();
    }

    public string getName(){
        return customerName;
    }
}
