using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrderSystem : MonoBehaviour
{
    public static OrderSystem instance;
    public List<Order> orders = new List<Order>();
    Order activeOrder;
    bool playerIsHere;

    bool isOrderStarted;

    public bool IsOrderStarted => isOrderStarted;

    int currentSceneIndex;

    public GameObject startOrderCanvas;

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

            // when reached final level
            if(currentSceneIndex == 4)
            {
                // load back to main menu
                SceneManager.LoadScene(0);
            }
            // load next scene
            SceneManager.LoadScene(currentSceneIndex + 1);

        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Motorcycle"))
        {
            playerIsHere = true;
            startOrderCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Motorcycle"))
        {
            playerIsHere = false;
            startOrderCanvas.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        isOrderStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerIsHere)
        {
            addOrder();
            Debug.Log("New Order Started.");
            isOrderStarted = true;
        }
    }
}
