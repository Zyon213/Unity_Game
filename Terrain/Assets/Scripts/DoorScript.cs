using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
public class DoorScript : MonoBehaviour
{
    //   private TextMeshProUGUI keyText;
    public GameObject keyText;
    public GameObject doorCollider;
    [SerializeField] Animator myDoor = null;
    [SerializeField] private bool openDoor;
    [SerializeField] private bool closeDoor;
    public bool _isKey;

    private void Start()
    {
        keyText.SetActive(false);
        _isKey = false;
        openDoor = false;
        closeDoor = false;
        doorCollider.GetComponent<BoxCollider>().enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        if (other.tag == "Player")
        {
            if(!openDoor && !closeDoor && _isKey)
            {
                openDoor = true;
                myDoor.Play("OpenDoor", 0, 0.0f);
                doorCollider.GetComponent<BoxCollider>().enabled = false;
            }
            /*
            else if (!closeDoor && openDoor && _isKey)
            {
                openDoor = false;
                myDoor.Play("CloseDoor", 0, 0.0f);
                doorCollider.SetActive(true);
                doorCollider.GetComponent<BoxCollider>().enabled = true;
            }
            */
            else if (!openDoor && !closeDoor && !_isKey)
            {
                doorCollider.GetComponent<BoxCollider>().enabled = true;
                keyText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        keyText.SetActive(false);
 if (!closeDoor && openDoor && _isKey)
 {
     openDoor = false;
     myDoor.Play("CloseDoor", 0, 0.0f);
  //   doorCollider.SetActive(true);
     doorCollider.GetComponent<BoxCollider>().enabled = true;
 }
 
    }

}
