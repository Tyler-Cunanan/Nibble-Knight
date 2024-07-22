using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwissInventoryScript : MonoBehaviour
{

    private int coinsCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Creates a PlayerPrefs for coins collected if it doesn't exist.
        PlayerPrefs.SetFloat("SwissCollectedCoins", coinsCollected);
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            coinsCollected++;
            PlayerPrefs.SetFloat("SwissCollectedCoins", coinsCollected);
        }
    }

    public void SubtractCoins(int numOfCoins)
    {
        if(numOfCoins > coinsCollected)
        {
            Debug.Log("Error: numOfCoins is greater than coinsCollected, resulting into a negative result!");
            return;
        }
        coinsCollected -= numOfCoins;
    }

    public int GetCoinsCollected()
    {
        return coinsCollected;
    }
}
