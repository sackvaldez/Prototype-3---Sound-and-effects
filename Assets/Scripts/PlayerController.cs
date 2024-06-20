using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    // Animation type variable
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        // Get gravity component from Player´s Inspector
        playerRb = GetComponent<Rigidbody>();
        // Get animator component from Player´s Inspector
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // When Spacebar pressed and player is touching the ground AND is not gameOver, jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            // When jumping, trigger the jump animation
            playerAnim.SetTrigger("Jump_trig");
            // Stop dirt animation while jumping
            dirtParticle.Stop();
            // Sound effect of jumping
            playerAudio.PlayOneShot(jumpSound);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // If there is a collision with the gameObject tagged as "Ground", isOnGround state is changed to True
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        // If collition with Obstacle tagged gameObject, gameOver is printed as a Debug message
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            // We play the explosion particle effect animation when colliding with obstacle and stop the dirt one
            explosionParticle.Play();
            dirtParticle.Stop();
            // Sound effect of crash
            playerAudio.PlayOneShot(crashSound);
            // In order to active death animation, we have to put two conditions: Death_b to true and DeathType_int to 1 (cus it exists two different deaths)
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over!");
        }

    }
}
