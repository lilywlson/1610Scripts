using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollision : MonoBehaviour
{

    public int pickUpCounter;

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
        }
    }
}
