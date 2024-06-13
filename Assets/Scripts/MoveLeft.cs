using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to move gameObject to the left of the scene
public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    // Variable to connect with another script
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        // Find the "Player" gameObject to get its component, in this case, the "PlayerController" script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // While gameOver is not true, keep moving left
        if (playerControllerScript.gameOver == false)
        {
            // X axis movement using time and speed variable
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

    }
}
