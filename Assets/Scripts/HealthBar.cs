using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;
    // Start is called before the first frame update

    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
            SceneManager.LoadScene(currentSceneIndex);

        if(healthSlider.value != health) 
        {
            healthSlider.value = health;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
