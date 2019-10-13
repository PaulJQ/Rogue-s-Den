using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
    }
}
