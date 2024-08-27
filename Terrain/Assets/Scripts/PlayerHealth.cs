using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth;
    public Image healthBar;
    // Start is called before the first frame update

    private void Start()
    {
        health = maxHealth;
    }
    

    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
}
