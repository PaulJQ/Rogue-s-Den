using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public GameObject currentInterObj = null;

    private void Update()
    {
        if (Input.GetButtonDown("interact") && currentInterObj)
        {
            currentInterObj.SendMessage("DoInteraction");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ( other.CompareTag ("interObject")) {
            if (other.gameObject == currentInterObj) {
                Debug.Log (other.name);
                currentInterObj = null;
            }
        }
    }
}
