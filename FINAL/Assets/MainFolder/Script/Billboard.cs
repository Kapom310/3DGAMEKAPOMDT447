using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public GameManager Manager;
    public NewPlayerMovement NPM;
    public AudioClip CoinSound; 
    public AudioSource audioSource; // Reference to the AudioSource component


    // Start is called before the first frame update
    private void Start()
    {
        // Get the AudioSource component (add one if it doesn't exist)
        //audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(" Hit ");

            Manager.UpdateCoin();
            NPM.glideTimer = 0;
            
            if (this.CompareTag("Coin"))
            {
                audioSource.PlayOneShot(CoinSound);
                Destroy(gameObject);
            }
           
        }
       
    }


}
