using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessingComputer : MonoBehaviour
{
    public GameObject player;
    public GameObject computerScreenGUI;
    public GameObject playerGUI;

    // Start is called before the first frame update
    void Start()
    {
        computerScreenGUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float minDistance = 2.5f;
        float distanceBetween = Vector3.Distance(player.transform.position, transform.position);

        if(distanceBetween < minDistance){
            if(Input.GetKeyDown(KeyCode.E)){
                Debug.Log("Access Computer");

                //Make the GUI Visible, turn on the cursor, etc.
                computerScreenGUI.SetActive(true);
                playerGUI.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
