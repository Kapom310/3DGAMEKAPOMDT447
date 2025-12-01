using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinEvent : MonoBehaviour
{
    public GameObject firstOBJ;
    public GameObject secondOBJ;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        firstOBJ.SetActive(true);
        secondOBJ.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (firstOBJ.activeSelf && gm.objectiveComplete) 
        {
            firstOBJ.SetActive(false);
            secondOBJ.SetActive(true);
        }
    }
}
