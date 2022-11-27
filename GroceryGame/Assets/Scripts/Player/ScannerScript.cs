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
    public int currItemIndex;

    [Header("Tablet GUI Update")]
    public Transform parentOfItemObjects;

    // Start is called before the first frame update
    void Start()
    {
        orderSentOver = false;
        instructionScreen.SetActive(true);
        customerOrderScreen.SetActive(false);

        _mainCamera = Camera.main;
        currItemIndex = 0;
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
                scanItem(scan());
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
    private string scan(){
        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit)){
            objectHit = hit.transform.gameObject;
        }

        return objectHit.name;
    }
    


    //According to the checkItemScanned(), the correct response will happen
    void scanItem(string objectScannerHit){
        if(objectScannerHit == customerOrder[currItemIndex].getName()){
            addToBag();
        } else{
            scanError();
        }
    }

    //If item is on list
    void addToBag(){
        currItemIndex++;
        Debug.Log("Added");
    }

    //If item is not on list
    void scanError(){
        Debug.Log("Error");
    }

    void setToSelected(int index){
        Image indexValueImage = parentOfItemObjects.GetChild(index).GetComponent<Image>();
        indexValueImage.color = new Color32(34, 201, 236, 255);
    }

    void setToRecieved(int index){
        Image indexValueImage = parentOfItemObjects.GetChild(index).GetComponent<Image>();
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