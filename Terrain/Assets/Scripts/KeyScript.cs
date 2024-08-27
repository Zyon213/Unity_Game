using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public DoorScript doorKey;
    public GameObject keyMsg;
    // Start is called before the first frame update

    private void Start()
    {
        keyMsg.SetActive(false);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorKey._isKey = true;
            keyMsg.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        keyMsg.SetActive(false);
        Destroy(gameObject);
  
    }

}
