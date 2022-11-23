/*
 What this script does
  - Adds functionality to scanner/tablet
  - Scans objects
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerScript : MonoBehaviour
{

    public ComputerProgram computerScriptRef;
    private Camera _mainCamera;
    private Item[] customerOrder;

    GameObject objectHit;

    public GameObject instructionScreen;
    public GameObject customerOrderScreen;

    public bool orderSentOver;

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

    //Send the raycast and and get the object name 
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
        foreach(Item item in computerScriptRef.currCustomerOrder){
            if(item.getName() == target){
                Debug.Log(item.getName() + " = " + target);
                return true;
            }
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
}
