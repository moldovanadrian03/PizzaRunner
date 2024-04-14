using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour
{
    public Text goldText;
    private int collectedGold = 0;

    void Update()
    {
        goldText.text = "Gold: " + collectedGold.ToString();
    }

    public void CollectGold(int amount)
    {
        collectedGold += amount;
    }
}