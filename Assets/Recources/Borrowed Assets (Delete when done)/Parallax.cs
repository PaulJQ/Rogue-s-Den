using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCamPos;
    public float backgroundTargetPosX;
    Vector3 startingCamPosition;
    Vector3[] startingBackgroundPositions;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        startingCamPosition = cam.position;
        parallaxScales = new float[backgrounds.Length];
        startingBackgroundPositions = new Vector3[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = 1 / backgrounds[i].position.z * -1;
            startingBackgroundPositions[i] = backgrounds[i].position; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.position != startingCamPosition)
        {
            Vector3 offset = cam.position - startingCamPosition;

            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].position = startingBackgroundPositions[i] + offset * parallaxScales[i];
            }
        }
    }
}
