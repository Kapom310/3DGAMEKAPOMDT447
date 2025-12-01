using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatCode : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the 'L' key is held down
        if (Input.GetKey(KeyCode.L))
        {
            // Check for number key presses (1-4)
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                LoadSceneByIndex(1); // Load scene with build index 1
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                LoadSceneByIndex(2); // Load scene with build index 2
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                LoadSceneByIndex(3); // Load scene with build index 3
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                LoadSceneByIndex(4); // Load scene with build index 4
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadSceneByIndex(0); // Load scene with build index 0 (e.g., main menu)
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            DisableEnemies();
        }


    }

    // Method to load a scene by build index
    private void LoadSceneByIndex(int index)
    {
        // Check if the scene index is valid
        if (index >= 0 && index < SceneManager.sceneCountInBuildSettings)
        {
            // Unlock and show the cursor if loading the main menu (index 0)
            if (index == 0)
            {
                Cursor.lockState = CursorLockMode.None; // Unlock the cursor
                Cursor.visible = true; // Make the cursor visible
            }

            SceneManager.LoadScene(index);
            Debug.Log("Loading scene with index: " + index);
        }
        else
        {
            Debug.LogWarning("Invalid scene index: " + index);
        }
    }

    private void DisableEnemies()
    {
        // Find all GameObjects with the "Enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Disable each enemy
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }

        Debug.Log("Disabled " + enemies.Length + " enemies.");
    }
}