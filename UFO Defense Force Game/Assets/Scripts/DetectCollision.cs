using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private ScoreManager scoreManager; // variable to hold ref to scoremanager
    public int scoreToGive;
    public ParticleSystem explosionParticle; // store particle system

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); // ref scoremanager
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LazerBolt"))
        {
            Destroy(gameObject); // destroy ufo
            Destroy(other.gameObject); // destroy blaster bolt
            Explosion();
        }

        scoreManager.IncreaseScore(scoreToGive); // inc score
    }

    void Explosion()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
    }
}
