using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to move gameObject to the left of the scene
public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // X axis movement using time and speed variable
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
