using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    private GameManager gm;
    private Renderer flagRend;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        flagRend = GameObject.Find("PlayerFlag").GetComponent<Renderer>();
        flagRend.enabled = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && gm.hasFlag)
        {
            Debug.Log("Player has reached homebase.");
            // gm.PlaceFlag();
            flagRend.enabled = true;
        }
    }
}
