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

    // Start is called before the first frame update
    void Start()
    {
        listOfCustomers = new RoundCustomers().listOfCustomers; //Creates a new round of customers
        showNavigationButtons();
        fillCustomerInfo(customerTracker);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        for(int x = 0; x < currCustomerOrder.Length; x++){
            GameObject itemChild = Instantiate(instantiatedTemplate, parentObject.transform);
            itemChild.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = x.ToString() + ": " + currCustomerOrder[x].getName(); //Will set the name of the instantiated game object
            
        }
        
        /*
        foreach(Item item in listOfCustomers[customerIndexValue].getOrder()){
            GameObject itemChild = Instantiate(instantiatedTemplate, parentObject.transform);
        }*/
    }
}
