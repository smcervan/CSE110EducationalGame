using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerDisplay : MonoBehaviour
{

    public Transform containerDisplay; // Parent Object
    public GameObject itemDisplay; //Instance Object

    Customer[] listOfCustomers; //List of Customers
    int minCustomers = 1; // Minimum amount of Customers
    int maxCustomers = 6; // Maximum Amount of Customers

    //public int customerTracker = 0;
    //public GameObject navigationContainer;


    // Start is called before the first frame update
    void Start()
    {
        createCustomers();
        displayCustomerOrder(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createCustomers(){
        System.Random randomGen = new System.Random(); // Random num generator
        int numberOfCustomers = randomGen.Next(minCustomers, maxCustomers); // Creating the amount of customers the player must get through
        
        Debug.Log(numberOfCustomers);
        listOfCustomers = new Customer[numberOfCustomers]; // Created the arry for each customer

        //showNavigationButtons();

        for(int x = 0; x < listOfCustomers.Length; x++){
            listOfCustomers[x] = new Customer(randomNameGenerator()); // Refer to customer through index rather than variable name
        }

    }

    string randomNameGenerator(){ // This is pretty rad if you ask me
        string name = "";
        string[] firstNames = {"James", "Mary", "Robert", "Patricia", "John", "Jennifer", "Michael", "Linda", "David", "Elizabeth"};
        string[] lastNames = {"Johnson", "Williams", "Davis", "Jones", "Garcia", "Martinez","Lee", "Sanchez", "Knight", "King"};
        System.Random randomNum = new System.Random();

        name += firstNames[randomNum.Next(0, 10)];
        name += " ";
        name += lastNames[randomNum.Next(0, 10)];

        return name;
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

    void flushItemDisplay(){
        for(int x = 0; x < containerDisplay.childCount; x++){
            Destroy(containerDisplay.GetChild(x).gameObject);
        }
    }

    /* GUI Customer Navigation
    void showNavigationButtons(){
        if(listOfCustomers.Length == 1){
            navigationContainer.SetActive(false);
        } else{
            navigationContainer.SetActive(true);
        }
    }

    public void nextCustomer(){
        flushItemDisplay();
        customerTracker++;
        if(customerTracker >= listOfCustomers.Length){
            customerTracker = 0;
        }
        displayCustomerOrder(customerTracker);
    }

    public void previousCustomer(){
        flushItemDisplay();
        customerTracker--;
        if(customerTracker <= 0){
            customerTracker = listOfCustomers.Length - 1;
        }
        displayCustomerOrder(customerTracker);
    }
    */

}
