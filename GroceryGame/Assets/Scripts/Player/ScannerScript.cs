/*
 What this script does
  - Adds functionality to scanner/tablet
  - Scans objects
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScannerScript : MonoBehaviour
{
    [Header("Object Variables")]
    public ComputerProgram computerScriptRef;
    private Camera _mainCamera;
    private Item[] customerOrder;

    [Header("Raycast")]
    GameObject objectHit;

    [Header("GUI for Tablet Screens")]
    public GameObject instructionScreen;
    public GameObject customerOrderScreen;

    [Header("Order Logic Variables")]
    public bool orderSentOver;
    public int currItemIndex = 0;

    [Header("Tablet GUI Update")]
    public Transform parentOfItemObjects;

    // Start is called before the first frame update
    void Start()
    {
        orderSentOver = false;
        instructionScreen.SetActive(true);
        customerOrderScreen.SetActive(false);

        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)){
            zoomTablet();
        } else{
            gameObject.transform.localPosition = new Vector3(0.5f,-0.45f,0.9f);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
        //Player can scan Items
        if(orderSentOver == true){
            customerOrder = computerScriptRef.currCustomerOrder;
            instructionScreen.SetActive(false);
            customerOrderScreen.SetActive(true);

            if(Input.GetMouseButtonDown(0)){
                scanItem(scan().name);
            } 
        }
    }

    void zoomTablet(){
        Vector3 zoomMode = new Vector3( 0.5f, -0.25f, 0.9f);
        gameObject.transform.localPosition = zoomMode;
        transform.localRotation = Quaternion.Euler(-90f, 25f, 0f);
    }

    //Checks to see if the item scanned in the order
    /*
        The target is going to be selected through the update statement 
        and will then be passed down to the scanItem method. It will be
        according to a tracer that the player will shoot out, which will
        then get the item object and pass it to the method.

        Raycast hit.
    */

    //Send the raycast and and get the object name that is being hit
    private GameObject scan(){
        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit)){
            objectHit = hit.transform.gameObject;
            Debug.Log(objectHit.name);
        }

        return objectHit;
    }
    

    //According to the checkItemScanned(), the correct response will happen
    void scanItem(string target){
        if(checkItemScanned(target) == true){
            addToBag();
        } else if(checkItemScanned(target) == false){
            scanError();
        }
    }

    //Checks to see if the item is in the list, returns bool to scanItemMethod
    bool checkItemScanned(string target){
        if(target == customerOrder[currItemIndex].getName()){
            Debug.Log("The correct item has been scanned");
            currItemIndex++;
            return true;
        }
        return false;
    }

    //If item is on list
    void addToBag(){
        Debug.Log("Item added to bag, check off list");
    }

    //If item is not on list
    void scanError(){
        Debug.Log("Item not in bag, scan error");
    }

    void setToSelected(){
        Image indexValueImage = parentOfItemObjects.GetChild(currItemIndex).GetComponent<Image>();
        indexValueImage.color = new Color32(34, 201, 236, 255);
    }

    void setToRecieved(){
        Image indexValueImage = parentOfItemObjects.GetChild(currItemIndex).GetComponent<Image>();
        indexValueImage.color = new Color32(132, 234, 112, 255);
    }
}

/*

Sets the index UI of the current item to blue,
the player scans an object
see if the scanned object lines up with the current item 
if it does - move on to the next object,
           - turn to green
if it doesn't - does not match error

*/