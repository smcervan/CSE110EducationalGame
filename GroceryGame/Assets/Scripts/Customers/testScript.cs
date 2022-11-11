using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{

    public Order newOrder = null;
    public Order newOrder2 = null;
    public Order newOrder3 = null;

    // Start is called before the first frame update
    void Start()
    {
        newOrder = new Order();
        newOrder.printCustomerOrder();
        
        Debug.Log("------------Next Order----------");

        newOrder2 = new Order();
        newOrder2.printCustomerOrder();

        Debug.Log("------------Next Order----------");

        newOrder3 = new Order();
        newOrder3.printCustomerOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
