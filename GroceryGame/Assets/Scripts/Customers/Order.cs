using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Order
{
    private int orderLength;
    private ArrayList itemsAvailable = null;
    private Item[] customerOrder = null;

    //Default constructor
    public Order(){
        itemsAvailable = new ArrayList();
        addData(); //Assigns all items into the itemsAvailable ArrayList
        createRandomOrder(); //Creates an order and fills the customerOrder array
    }

    private void addData(){
        Item orange = new Item("orange" , 0.15, "fruit");
        Item apple = new Item("apple", 0.15 , "fruit");
        Item waterMelon = new Item("watermelon", 1.30, "fruit");
        Item banana = new Item("banana", 0.23 , "fruit");
        Item celery = new Item("celery", 1.40 , "fruit");
        Item carrots = new Item("carrots", 2.00 , "fruit");
        Item potato = new Item("potato", 0.23 , "fruit");
        Item milk = new Item("milk", 2.70 , "refrigerated");
        Item juice = new Item("juice", 3.00 , "refrigerated");
        Item cheese = new Item("cheese", 2.50 , "refrigerated");
        Item ham = new Item("ham", 2.50 , "refrigerated");
        Item cold_Lunch = new Item("cold_Lunch", 4.50 , "refrigerated");
        Item bacon = new Item("bacon", 4.50 , "refrigerated");
        Item pizza = new Item("pizza", 12.00 , "frozen");
        Item ice_cream = new Item("ice_cream", 6.00 , "frozen");
        Item lasagna = new Item("lasagna", 12.00 , "frozen");
        Item dino_nuggets = new Item("dino_nuggets", 15.00 , "frozen");
        Item frozen_diner = new Item("frozen_diner", 12.00 , "frozen");
        Item pizza_pockets = new Item("pizza_pockets", 10.00 , "frozen");
        Item chips = new Item("chips", 6.00 , "dry");
        Item crackers = new Item("crackers", 5.00 , "dry");
        Item cookies = new Item("cookies", 5.00 , "dry");
        Item box_food = new Item("box_food", 5.00 , "dry");
        Item noodles = new Item("noodles", 1.00 , "dry");
        Item toilet_paper = new Item("toilet_paper", 12.00 , "hygeine");
        Item napkins = new Item("napkins", 8.00 , "hygeine");
        Item trash_bags = new Item("trash_bags", 7.00 , "hygeine");
        Item soap = new Item("soap", 4.00 , "hygeine");
        Item tooth_paste = new Item("tooth_paste", 4.00 , "hygeine");

        itemsAvailable.Add(orange);
        itemsAvailable.Add(apple);
        itemsAvailable.Add(waterMelon);
        itemsAvailable.Add(banana);
        itemsAvailable.Add(celery);
        itemsAvailable.Add(carrots);
        itemsAvailable.Add(potato);
        itemsAvailable.Add(milk);
        itemsAvailable.Add(juice);
        itemsAvailable.Add(cheese);
        itemsAvailable.Add(ham);
        itemsAvailable.Add(cold_Lunch);
        itemsAvailable.Add(bacon);
        itemsAvailable.Add(pizza);
        itemsAvailable.Add(ice_cream);
        itemsAvailable.Add(lasagna);
        itemsAvailable.Add(dino_nuggets);
        itemsAvailable.Add(frozen_diner);
        itemsAvailable.Add(pizza_pockets);
        itemsAvailable.Add(chips);
        itemsAvailable.Add(crackers);
        itemsAvailable.Add(cookies);
        itemsAvailable.Add(box_food);
        itemsAvailable.Add(noodles);
        itemsAvailable.Add(toilet_paper);
        itemsAvailable.Add(napkins);
        itemsAvailable.Add(trash_bags);
        itemsAvailable.Add(soap);
        itemsAvailable.Add(tooth_paste);
    }

    private void createRandomOrder(){
        //Order Length
        int minLength = 1;
        int maxLength = 10;

        //create order length
        System.Random rndLength = new System.Random();
        int orderLength = rndLength.Next(minLength, maxLength);

        //Update customerOrder
        customerOrder = new Item[orderLength];

        //Creates the customers order
        for(int x = 0; x < orderLength; x++){
            System.Random rndGen = new System.Random();
            int randIndex = rndGen.Next(0, 29);

            customerOrder[x] = (Item)itemsAvailable[randIndex];
        }
    }

    public void printCustomerOrder(){
        foreach(Item currItem in customerOrder){
            Debug.Log(currItem.getName());
        }
    }

    public Item[] getOrder(){
        return customerOrder;
    }

    public Item getItemAtIndex(int indexValue){
        return customerOrder[indexValue];
    }
}
