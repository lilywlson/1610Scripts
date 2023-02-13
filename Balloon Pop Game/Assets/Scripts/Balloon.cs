using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int clicksToPop = 3; // How many clicks before balloon pops
    public float scaleToInc = 0.1f; // Scale increase each time balloon clicked
    public ScoreManager scoreManager; // A reference to score manager
    public int scoreToGive = 100;
    void Start()
    {
        // Get ScoreManager Component
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    void OnMouseDown()
    {
        clicksToPop --; // Reduce clicks by one
        transform.localScale += Vector3.one * scaleToInc; // Inflate balloon
        if(clicksToPop == 0)
        {
            // Tell the Score Manager to increase the score by a certain amount
            scoreManager.IncreaseScoreText(scoreToGive);
            Destroy(gameObject); // Destroy and remove balloon when clicked to pop
        }
    }
}