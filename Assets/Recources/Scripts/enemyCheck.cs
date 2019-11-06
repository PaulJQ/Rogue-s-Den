using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCheck : MonoBehaviour
{
    public EnemyBehavior enemyBehavior;

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
            enemyBehavior.target = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject == enemyBehavior.target)
            {
                enemyBehavior.target = null;
            }
        }
    }
}
