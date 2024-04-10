using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "OrderSystem")]
public class Order : ScriptableObject
{
    public int cash;
    public int id;
    public GameObject deliveryGoal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
