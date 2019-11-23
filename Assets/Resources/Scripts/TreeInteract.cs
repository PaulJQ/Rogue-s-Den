using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract : MonoBehaviour
{
    public GameObject target;
    public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerBehavior>().visable == true)
        {
            if (Input.GetKeyDown("Interact"))
            {
                target = other.gameObject;
                Instantiate(Item, transform.position, Item.transform.rotation);
            }
        }
    } 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject == target)
            {
                target = null;
            }
        }
    }
}
