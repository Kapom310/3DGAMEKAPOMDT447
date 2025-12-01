using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Coin Settings")]
    [SerializeField] private int totalCoin;
    [SerializeField] public bool collectCoin = false;
    [SerializeField] private int coinNeeded = 0;

    [Header("Objective")]
    public GameObject platform;
    public bool objectiveComplete;

    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        totalCoin = 5;
        platform.SetActive(false);

        if (collectCoin)
        {
            coinNeeded = GameObject.FindGameObjectsWithTag("Coin").Length;
            objectiveComplete = false;
        }
    }

    public void UpdateCoin()
    {
        totalCoin += 1;
        if (totalCoin >= coinNeeded && collectCoin)
        {
            platform.SetActive(true);
            objectiveComplete = true;
        }
    }

    public void BuyItem()
    {
        // Example purchase: costs 5 coins
        if (totalCoin >= 5)
        {
            totalCoin -= 5;
            Debug.Log("Item purchased!");
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }
}
