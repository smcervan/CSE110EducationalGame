using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ComputerProgram : MonoBehaviour
{
    [Header("General Information")]
    public Customer[] listOfCustomers;
    public int customerTracker = 0; //Starting index for customer navigation
    public Item[] currCustomerOrder;

    [Header("GUI References for Customer Side")]
    public TMP_Text customerIndexNav;
    public TMP_Text customerName;
    public TMP_Text customerOrderLength;
    public TMP_Text customerOrderTotal;

    public GameObject navigationButtons;
    public GameObject parentObject;
    public GameObject instantiatedTemplate;

    [Header("Selected Customer References")]
    // Gameobjecet , for selected customer side (educational side)
    public GameObject selectedItemTemplate; //Instantiate Template for the selected customer's items
    public Transform selectedObjectsParent; 

    public Question[] codingQuestions;
    public GameObject[] codingObjects = new GameObject[5];

    public Customer selectedCustomer;

    [Header("Coding Question References")]
    public TMP_Text codingStatusText;
    TMP_Text playerInput;

    [Header("Gui GameObject References")]
    public GameObject computerScreenGUI;
    public GameObject sendingScreen;
    public GameObject logInScreen;
    public GameObject programInterface;
    public GameObject playerGUI;


    [Header("Tablet Information")]
    public Transform containerDisplay; //The parent Object
    public GameObject itemDisplay; //Instance Object
    public ScannerScript scannerScriptRef;

    // Start is called before the first frame update
    void Start()
    {
        listOfCustomers = new RoundCustomers().listOfCustomers; //Creates a new round of customers
        showNavigationButtons();
        fillCustomerInfo(customerTracker);

        sendingScreen.SetActive(false);
        logInScreen.SetActive(false);
        programInterface.SetActive(true);

        foreach(GameObject question in codingObjects){
            question.SetActive(false);
        }
    }
    
    //Navigation for customer Selection

    private void showNavigationButtons(){
        if(listOfCustomers.Length == 1){
            navigationButtons.SetActive(false);
        } else{
            navigationButtons.SetActive(true);
        }
    }

    public void nextCustomer(){
        flushInfo();
        customerTracker++;
        if(customerTracker >= listOfCustomers.Length){
            customerTracker = 0;
        }
        fillCustomerInfo(customerTracker);
    }

    public void previousCustomer(){
        flushInfo();
        customerTracker--;
        if(customerTracker <= 0){
            customerTracker = listOfCustomers.Length - 1;
        }
        fillCustomerInfo(customerTracker);
    }

    private void flushInfo(){
        customerIndexNav.text = " ";
        customerName.text = " ";
        customerOrderLength.text = " ";
        customerOrderTotal.text = " ";

        foreach(Transform child in parentObject.transform){
            Destroy(child.gameObject);
        }
    }

    private void fillCustomerInfo(int customerIndexValue){
        //Basic Customer Info
        customerIndexNav.text = "Customer #" + customerIndexValue.ToString(); //Assigns the index value to the customer
        customerName.text = listOfCustomers[customerIndexValue].getName();
        customerOrderLength.text = listOfCustomers[customerIndexValue].getOrder().Length.ToString();
        customerOrderTotal.text = "$" + listOfCustomers[customerIndexValue].getOrderTotal().ToString();

        //Customer Items
        Item[] currCustomerOrder = listOfCustomers[customerIndexValue].getOrder();
        int i = 0;
        for(int x = 0; x < currCustomerOrder.Length; x++){
            i = x + 1;
            GameObject itemChild = Instantiate(instantiatedTemplate, parentObject.transform);
            itemChild.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = i.ToString() + ": " + currCustomerOrder[x].getName(); //Will set the name of the instantiated game object
            
        }
        
        /*
        foreach(Item item in listOfCustomers[customerIndexValue].getOrder()){
            GameObject itemChild = Instantiate(instantiatedTemplate, parentObject.transform);
        }*/
    }

    // ---------- Selected Customer Screen ----------

    //Get current customer, display objects to selected Screen
    private void customerSelected(){
        selectedCustomer = listOfCustomers[customerTracker]; //This getting the current customer
        currCustomerOrder = selectedCustomer.getOrder(); //Get the current customer's list of items

        for(int x = 0;x < currCustomerOrder.Length; x++){ //Moves the customer's list to the selcted display
            GameObject newSelectedItem = Instantiate(selectedItemTemplate, selectedObjectsParent);
            
            newSelectedItem.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = currCustomerOrder[x].getName();
            newSelectedItem.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = x.ToString();
        }

        codingObjects[selectedCustomer.getQuestionIndex()].SetActive(true); //Sets the current coding problem visible
    }

    //When selecting the customers, will flush out previous data
    private void flushSelectedItems(){ 
        //This loop will delete the children from the parent obejct
        foreach(Transform child in selectedObjectsParent){
            Destroy(child.gameObject);
        }

    }

        //Shows the selected customers items
    public void showSelectedCustomersItems(){
        flushSelectedItems();
        flushQuestion();
        customerSelected();
    }

    // ---------- Coding Question Screen ----------

        //For each customer, there will be a different question to add variety and practice
    
    public void checkButtonPressed(){
        GameObject questionReference = codingObjects[selectedCustomer.getQuestionIndex()];

        string userInput = questionReference.transform.GetChild(1).GetComponent<TMP_InputField>().text; //Gets input from the user
        string questionAnswer = selectedCustomer.getQuestionAnswer(); //Gets the answer from the class
        //TMP_Text statusText = questionReference.
        //Get the status text


        if(userInput.Equals(questionAnswer)){
            //Set the status text to be green and change text
            codingStatusText.color = new Color32(94, 200, 61, 255);
            codingStatusText.text = "Correct!";

            //Send to tablet
            //Display sending screen animation
            displayCustomerOrder(customerTracker);
            scannerScriptRef.orderSentOver = true;

        } else{
            //Set the status text to be red and change text
            codingStatusText.color = new Color32(200, 75, 61, 255);
            codingStatusText.text = "Incorrect!";

            //Keep on trying
            scannerScriptRef.orderSentOver = false;
        }

        
    }

    //This is needed
    public void flushQuestion(){
        foreach(GameObject questionObject in codingObjects){
            questionObject.SetActive(false);
        }
    }

    //Closing the GUI
    public void closeComputerScreen(){
        computerScreenGUI.SetActive(false);
        programInterface.SetActive(false);
        logInScreen.SetActive(true);
        playerGUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    //After successfully completing the problem
    public void continueButtonPressed(){
        sendingScreen.SetActive(true);
    }

    //Log In Screen Coding
    public void logInButtonPressed(){
        logInScreen.SetActive(false);
        programInterface.SetActive(true);
    }


    //Display on tablet information
    //Selecting a customer, getting their order, and passing it to the method that displays the order info
    public void displayCustomerOrder(int customerIndex){        
        Customer currCustomer = listOfCustomers[customerIndex]; // Gets the customer index, selecting a customer 
        Item[] currCustomerOrder = currCustomer.getOrder(); // The currently selected customer's order

        currCustomer.getOrder();

        for(int x = 0; x < currCustomerOrder.Length; x++){ //Cycles through the order, creating a new item GUI object (setUIInfo method)
            setGUIInfo(x, currCustomerOrder[x]); // Passes the index value, and the current item in the order according to the index value
        }
    }

    //Cycling through the customer's order, creating item containers, which display the item's content to player through GUI
    public void setGUIInfo(int indexValue, Item item){ //Creates individual item container
        GameObject itemObject = Instantiate(itemDisplay,containerDisplay); // Creates the container
        //itemObject.transform.SetParent(containerDisplay); // Sets the grid as the parent

        TMP_Text itemIndexText = itemObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>(); // Accesses the index text
        TMP_Text itemNameText = itemObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>(); // Accesses the name text

        itemIndexText.text = indexValue.ToString(); // Updates the index text with the item's current index
        itemNameText.text = item.getName(); // Updates the name text with the item's name
    }

    
}
