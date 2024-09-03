using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] float amount;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //  private void OnCollisionEnter(Collision collision)
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(amount);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
