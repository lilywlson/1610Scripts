using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float upperBound = 15;
    public ScoreManager scoreManager; // Stores a reference to the Score Manager
    public Balloon balloon; // Reference the balloon script

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        balloon = GetComponent<Balloon>();
    }

    // Update is called once per frame
    void Update()
    {
        // Make the balloon float upward
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        if(transform.position.y > upperBound)
        {
            scoreManager.DecreaseScoreText(balloon.scoreToGive); // Reduces score when balloon passes threshold
            Destroy(gameObject); // Pops balloon
        }
    }
}