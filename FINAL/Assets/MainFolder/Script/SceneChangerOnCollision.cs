using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerOnCollision : MonoBehaviour
{
    [Header("Player Tag")]
    [Tooltip("Set this to the tag of the player object.")]
    public string playerTag = "Player";

    [Header("Scene Settings")]
    [Tooltip("Name of the scene to load on collision.")]
    public string sceneToLoad;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the player tag
        if (collision.gameObject.CompareTag(playerTag))
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Cursor not lock");
            }
            else
            {
                Debug.LogWarning("Scene name is not set in the inspector.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has the player tag
        if (other.CompareTag(playerTag))
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Cursor not lock");
            }
            else
            {
                Debug.LogWarning("Scene name is not set in the inspector.");
            }
        }
    }
}
