using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    public static OrderSystem instance;
    public List<Order> orders = new List<Order>();
    Order activeOrder;
    bool playerIsHere;

    private void Awake()
    {
        instance = this;
    }

    void addOrder()
    {
        if(activeOrder == null)
        {
            activeOrder = orders[Random.Range(0, orders.Count)];
        }
    }

    public int ReadActiveOrder()
    {
        return activeOrder.id;
    }

    public void CompleteOrder(int _id)
    {
        if(activeOrder == null)
        {
            return;
        }
        if(activeOrder.id == _id)
        {
            //order complete
            Debug.Log("Order number " + activeOrder.id + " is complete.");
            //cash
            activeOrder = null;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Motorcycle"))
        {
            playerIsHere = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Motorcycle"))
        {
            playerIsHere = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerIsHere)
        {
            addOrder();
            Debug.Log("New Order Started.");
        }
    }
}
