using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Variable to save background´s start position
    private Vector3 startPos;
    private float repeatWith;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        // We get the collider, 
        repeatWith = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // If background position in X is less than the result of the initial minus half the size of the background, return to starting position
        if (transform.position.x < startPos.x - repeatWith)
        {
            transform.position = startPos;
        }
    }
}
