using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{

    public bool m_hasObjective = false;
    public int m_numOfPointsNeeded = 0;

    public bool m_isFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player ran into NPC.");
            // Debug.Log(collision.gameObject.GetComponent<SwissInventoryScript>().GetCoinsCollected());
            if(m_isFinished)
            {
                Debug.Log("Thank you again! You are our hero of the sewers!");
                return;
            }
            if(m_hasObjective)
            {
                SwissInventoryScript m_inv = collision.gameObject.GetComponent<SwissInventoryScript>();
                if(m_inv.GetCoinsCollected() < m_numOfPointsNeeded)
                {
                    Debug.Log("Not enough coins. my friend. Please continue searching!");
                    Debug.Log("Current coin count: " + m_inv.GetCoinsCollected() + " Needed coin count: " + m_numOfPointsNeeded);
                }
                else 
                {
                    m_inv.SubtractCoins(m_numOfPointsNeeded);
                    Debug.Log("Thank you so much! With these coins we can now rebuild and help feed many more mice!");
                    Debug.Log("New coin count: " + m_inv.GetCoinsCollected());
                    m_isFinished = true;
                }
            }
        }
    }
}
