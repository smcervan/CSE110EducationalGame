/**
This script creates the customers for each round
**/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCustomers
{

    public Customer[] listOfCustomers; //Can now get the list of customers through dot notation
    private int minCustomers = 3;
    private int maxCustomers = 6;

    public RoundCustomers(){
        System.Random randomGen = new System.Random(); // Random num generator
        int numberOfCustomers = randomGen.Next(minCustomers, maxCustomers); // Creating the amount of customers the player must get through
        
        Debug.Log(numberOfCustomers);
        listOfCustomers = new Customer[numberOfCustomers]; // Created the arry for each customer

        //showNavigationButtons();

        for(int x = 0; x < listOfCustomers.Length; x++){
            listOfCustomers[x] = new Customer(randomNameGenerator()); // Refer to customer through index rather than variable name
        }
    }

    private string randomNameGenerator(){
        string name = "";
        string[] firstNames = {"James", "Mary", "Robert", "Patricia", "John", "Jennifer", "Michael", "Linda", "David", "Elizabeth"};
        string[] lastNames = {"Johnson", "Williams", "Davis", "Jones", "Garcia", "Martinez","Lee", "Sanchez", "Knight", "King"};
        System.Random randomNum = new System.Random();

        name += firstNames[randomNum.Next(0, 10)];
        name += " ";
        name += lastNames[randomNum.Next(0, 10)];

        return name;
    }
}
