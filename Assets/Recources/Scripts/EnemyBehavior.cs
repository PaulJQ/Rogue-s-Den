using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyBehavior : MonoBehaviour
{
    //Vector2 poc;
    public GameObject target = null;
   // public PlayerBehavior PlayerBehavior;
    public GameObject enemyProjectile;
   //private GameObject Enemy;
    //private bool enemyShoot;
    public float timeLimit = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target.CompareTag("Player"))
        {
            timeLimit -= Time.deltaTime;
            if (timeLimit <= 0)
            {
                var p = Instantiate(enemyProjectile, transform.position, enemyProjectile.transform.rotation);
                timeLimit = 10;
                p.GetComponent<EnemyProjectilebehavior>().target = target;
            }
            
        }
    }

}
