using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    private Slider HealthBar;
    public stats health;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = health.currentHealth / health.maxHealth;
    }
}
