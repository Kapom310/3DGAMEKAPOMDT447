using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JumPad : MonoBehaviour
{
    public float jumpForce = 20f; // The force applied to the player when they hit the jump pad
    public AudioClip jumpSound; // The sound to play when the jump pad is activated
    private AudioSource audioSource; // Reference to the AudioSource component
    public NewPlayerMovement NPM;

    private void Start()
    {
        // Get the AudioSource component (add one if it doesn't exist)
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       // NPM = other.GetComponent<NewPlayerMovement>();
        NPM.ResetGlider();
        Debug.Log("ON");
        // Check if the object that entered the trigger has a Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && other.CompareTag("Player"))
        {
            Debug.Log("Push");
            // Apply an upward force to the Rigidbody
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); // Reset vertical velocity for consistent jumps
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Play the jump sound
            if (jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
            else
            {
                Debug.LogWarning("Jump sound or AudioSource is missing!");
            }
        }
    }
}