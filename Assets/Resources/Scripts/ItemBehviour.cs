using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehviour : MonoBehaviour
{
    public float timelimit = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DeSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
