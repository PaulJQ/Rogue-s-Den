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
        if (other.CompareTag("Hide"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
        if (other.CompareTag("Slow"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
        if (other.CompareTag("Death"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
        if (other.CompareTag("Talk"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ( other.CompareTag ("Hide")) {
            if (other.gameObject == currentInterObj) {
                Debug.Log (other.name);
                currentInterObj = null;
            }
        }
        if (other.CompareTag("Slow"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
        if (other.CompareTag("Death"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
        if (other.CompareTag("Talk"))
        {
            if (other.gameObject == currentInterObj)
            {
                Debug.Log(other.name);
                currentInterObj = null;
            }
        }
    }
}
