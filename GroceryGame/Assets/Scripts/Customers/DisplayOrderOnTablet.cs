using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayOrderOnTablet : MonoBehaviour
{

    public Transform containerDisplay; // Parent Object
    public GameObject itemDisplay; //Instance Object

    public Customer[] listOfCustomers; //List of Customers

    //public int customerTracker = 0;
    //public GameObject navigationContainer;


    // Start is called before the first frame update
    void Start()
    {
        //displayCustomerOrder(0);
        listOfCustomers = new RoundCustomers().listOfCustomers;
        displayCustomerOrder(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Selecting a customer, getting their order, and passing it to the method that displays the order info
    void displayCustomerOrder(int customerIndex){        
        Customer currCustomer = listOfCustomers[customerIndex]; // Gets the customer index, selecting a customer 
        Item[] currCustomerOrder = currCustomer.getOrder(); // The currently selected customer's order

        currCustomer.getOrder();

        for(int x = 0; x < currCustomerOrder.Length; x++){ //Cycles through the order, creating a new item GUI object (setUIInfo method)
            setGUIInfo(x, currCustomerOrder[x]); // Passes the index value, and the current item in the order according to the index value
        }

    }

    //Cycling through the customer's order, creating item containers, which display the item's content to player through GUI
    void setGUIInfo(int indexValue, Item item){ //Creates individual item container
        GameObject itemObject = Instantiate(itemDisplay,containerDisplay); // Creates the container
        //itemObject.transform.SetParent(containerDisplay); // Sets the grid as the parent

        TMP_Text itemIndexText = itemObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>(); // Accesses the index text
        TMP_Text itemNameText = itemObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>(); // Accesses the name text

        itemIndexText.text = indexValue.ToString(); // Updates the index text with the item's current index
        itemNameText.text = item.getName(); // Updates the name text with the item's name
    }
}
