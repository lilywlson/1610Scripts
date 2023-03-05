using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horInput;
    public float speed = 25;
    public float xRange = 16;
    public Transform blaster;
    public GameObject lazerBolt;
    private AudioSource blasterAudio;
    public AudioClip lazerBlast;

    void Start()
    {
        blasterAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // set horizontal input
        horInput = Input.GetAxis("Horizontal");

        // moves player left and right
        transform.Translate(Vector3.right * horInput * Time.deltaTime * speed);

        // keep player within left bound
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }

        // keep player within right bound
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange,transform.position.y,transform.position.z);
        }

        // space bar fires lazer bolt and create lazerbolt at blaster position while keeping rotation
        if(Input.GetKeyDown(KeyCode.Space))
        {
            blasterAudio.PlayOneShot(lazerBlast,1.0f); // play audio sound clip
            Instantiate(lazerBolt, blaster.transform.position, lazerBolt.transform.rotation);
        }
    }

    // delete any object with a trigger that hits the player
     private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
