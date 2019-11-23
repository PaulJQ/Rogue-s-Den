using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectilebehavior : MonoBehaviour
{
    private Vector2 bulletpos;
    public GameObject target;
    public GameObject enemy;
    public GameObject self;
    public float speed;
    public Rigidbody2D rb2d;
    public float timelimit = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
        rb2d.AddForce(Vector3.left * speed, ForceMode2D.Impulse);
        StartCoroutine(desbullet(timelimit));

        
    }
    IEnumerator desbullet(float time) {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
    public double RadiansToDegrees(double radians)
    {
        double degrees = (180 / Math.PI) * radians;
        return (degrees);
    }
    public double DegreesToRadians (double degrees)
    {
        double radians = (Math.PI / 180) * degrees;
        return (radians);
    }
}
