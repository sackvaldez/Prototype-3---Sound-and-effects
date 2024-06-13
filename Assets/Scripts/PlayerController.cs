using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = false;
    // Start is called before the first frame update
    void Start()
    {
        // Get gravitiy component from Player´s Inspector
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // When Spacebar pressed and player is touching the ground, jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    // Function to detect ground state when player collition with ground 
    private void OnCollisionEnter()
    {
        isOnGround = true;
    }
}
