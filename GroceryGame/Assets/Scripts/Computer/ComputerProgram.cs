using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ComputerProgram : MonoBehaviour
{
    private Customer[] listOfCustomers;
    int customerTracker = 0; //Starting index for customer navigation

    //GUI reference obejcts, for customer side
    public TMP_Text customerIndexNav;
    public TMP_Text customerName;
    public TMP_Text customerOrderLength;
    public TMP_Text customerOrderTotal;
    
    public GameObject navigationButtons;
    public GameObject parentObject;
    public GameObject instantiatedTemplate;

    // Gameobjecet , for selected customer side (educational side)
    public GameObject selectedItemTemplate; //Instantiate Template for the selected customer's items
    public Transform selectedObjectsParent; 

    public Question[] codingQuestions;
    public GameObject[] codingObjects = new GameObject[5];

    public Customer selectedCustomer;

    //Check Coding Question
    public TMP_Text codingStatusText;
    TMP_Text playerInput;

    // Start is called before the first frame update
    void Start()
    {
        listOfCustomers = new RoundCustomers().listOfCustomers; //Creates a new round of customers
        showNavigationButtons();
        fillCustomerInfo(customerTracker);

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
        Item[] currCustomerOrder = selectedCustomer.getOrder(); //Get the current customer's list of items

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
        Debug.Log(selectedCustomer.getQuestionAnswer()); //Displays the answer, could be used when comparing the answers
        //Gets input from the user
        string userInput = codingObjects[selectedCustomer.getQuestionIndex()].transform.GetComponentInChildren<TextMeshProUGUI>().text.ToString();
        

    }

    //This is needed
    public void flushQuestion(){
        foreach(GameObject questionObject in codingObjects){
            questionObject.SetActive(false);
        }
    }

}
