using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderReciever : MonoBehaviour
{
    public int orderId;

    bool playerOnOrder;

    public GameObject orderInfoCanvas;
    private void OnTriggerEnter(Collider col)
    {
        orderInfoCanvas.SetActive(true);
        if (col.CompareTag("Motorcycle"))
        {
            playerOnOrder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        orderInfoCanvas.SetActive(false);   
    }

    // Start is called before the first frame update
    void Start()
    {
        playerOnOrder = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOnOrder && Input.GetKeyDown(KeyCode.Space)) 
        {
            OrderSystem.instance.CompleteOrder(orderId);
        }
    }
}
