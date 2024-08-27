using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageConroller : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Player")
      // (collision.gameObject.CompareTag("Player"))
     //     if (collision.gameObject.name == "JungleManBaseMesh")
        {
            print("collider");
        
            playerHealth.health -= damage;
         }
        
            }
}
