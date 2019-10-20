using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    public Transform player;

    private Vector3 playerStartPos;
    Vector3 startingCamPos;


    // Start is called before the first frame update
    void Start()
    {
        playerStartPos = player.position;
        startingCamPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startingCamPos + (player.position - playerStartPos);
    }
}
