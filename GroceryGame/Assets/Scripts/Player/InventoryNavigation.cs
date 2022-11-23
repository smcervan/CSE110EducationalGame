using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryNavigation : MonoBehaviour
{

    //This script is going to be attached to the player gameobject
    public GameObject[] playerInventory = new GameObject[2];
    private int currPlayerHand;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the first object to the hands
        currPlayerHand = 0;
        //Turns all items invisble
        foreach(GameObject item in playerInventory){
            item.SetActive(false);
        }
        //Sets the hands visible
        playerInventory[currPlayerHand].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        switchObjects();
    }

    void switchObjects(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            flushHand();
            playerInventory[0].SetActive(true);
        } else if(Input.GetKeyDown(KeyCode.Alpha2)){
            flushHand();
            playerInventory[1].SetActive(true);
        }
    }

    void flushHand(){
        foreach(GameObject item in playerInventory){
            item.SetActive(false);
        }
    }
}
