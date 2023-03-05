using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSounds : MonoBehaviour
{
    private AudioSource explosionAudio;
    public AudioClip explosionBlast;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "UFO")
        {
            explosionAudio = GetComponent<AudioSource>();
            explosionAudio.clip = explosionBlast;
            explosionAudio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
