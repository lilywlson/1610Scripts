using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollision : MonoBehaviour
{

    private ScoreManager scoreManager;
    public int pickUpCounter;
    public int scoreToGive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // destroy pickup
            pickUpCounter ++;
            scoreManager.IncreaseScore(scoreToGive); // inc score
        }
    }
}
