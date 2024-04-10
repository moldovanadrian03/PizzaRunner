using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderReciever : MonoBehaviour
{
    public int orderId;
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Motorcycle"))
        {
            OrderSystem.instance.CompleteOrder(orderId);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
