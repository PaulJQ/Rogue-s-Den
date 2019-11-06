using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectilebehavior : MonoBehaviour
{
    private Vector2 bulletpos;
    public GameObject target;
    public float speed;
    public Rigidbody2D rb2d;
    public float timelimit = 2f;
   
    // Start is called before the first frame update
    void Start()
    {
        
        rb2d.AddForce(Vector3.left * speed, ForceMode2D.Impulse);
        StartCoroutine(desbullet(timelimit));

        
    }

    // Update is called once per frame
    IEnumerator desbullet(float time) {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
