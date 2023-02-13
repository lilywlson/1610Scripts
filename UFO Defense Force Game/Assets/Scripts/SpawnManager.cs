using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float speed = 25;
    public float xRange = 16;
    public float timer = 0;
    public Transform spawner;
    public GameObject pickUp;

    // Update is called once per frame
    void Update()
    {
        // moves player left and right
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        // keep player within left bound
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }

        // keep player within right bound
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }

        timer = timer + 1;

        // space bar fires lazer bolt and create lazerbolt at blaster position while keeping rotation
        if(timer >= 3000)
        {
            timer = 0;
            Instantiate(pickUp, spawner.transform.position, pickUp.transform.rotation);
        }
    }
}
