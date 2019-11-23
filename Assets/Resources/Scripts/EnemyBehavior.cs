using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyBehavior : MonoBehaviour
{
    public GameObject target = null;
    public GameObject enemyProjectile;
    public GameObject enemy = null;
    public EnemyProjectilebehavior enemyProjectilebehavior;
    public Rigidbody2D rb2d;
    private bool FacingRight = true;
    public float timeLimit = 2;
    public float bulletForce;

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyProjectilebehavior = enemyProjectile.GetComponent<EnemyProjectilebehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (target.CompareTag("Player"))
            {
                timeLimit -= Time.deltaTime;
                if (timeLimit <= 0)
                {
                    var distanceToPlayer = target.transform.position - enemy.transform.position;
                    var isPlayerAbove = distanceToPlayer.y >= 0;
                    var isPlayerRight = distanceToPlayer.x > 0;
                    var angleToPlayer = enemyProjectilebehavior.RadiansToDegrees(Math.Atan(distanceToPlayer.y / distanceToPlayer.x));
                    var projectileRotation = enemyProjectile.transform.rotation;
                    var bulletForce = new Vector2(enemyProjectilebehavior.speed * (float)Math.Cos(enemyProjectilebehavior.DegreesToRadians(angleToPlayer)),
                enemyProjectilebehavior.speed * (float)Math.Sin(enemyProjectilebehavior.DegreesToRadians(angleToPlayer)));
                    if (isPlayerRight)
                        rb2d.AddForce(-bulletForce);
                    else
                    {
                        rb2d.AddForce(bulletForce);
                    }
                    var p = Instantiate(enemyProjectile, transform.position, enemyProjectile.transform.rotation);
                    
                    timeLimit = 10;
                    p.GetComponent<EnemyProjectilebehavior>().target = target;

                }

            }
        }
        
    }

}
