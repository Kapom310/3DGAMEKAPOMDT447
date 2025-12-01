using UnityEngine;
using UnityEngine.Events;

public class NPCMerchant : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject dialogueUI; // Your Game Space UI
    [SerializeField] private string interactKey = "b"; // Key to trigger exchange
    [SerializeField] private UnityEvent onExchange; // Optional: assign in Inspector

    private bool playerInRange = false;

    private void Start()
    {
        if (dialogueUI != null)
            dialogueUI.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            Debug.Log("Exchange triggered with merchant!");
            onExchange.Invoke(); // Runs any assigned events
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (dialogueUI != null)
                dialogueUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (dialogueUI != null)
                dialogueUI.SetActive(false);
        }
    }
}
