using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum PickupType
    {
        Health,
        Ammo
    }

public class Pickup : MonoBehaviour
{
    private PlayerController playCon;
    private Health player;
    private GameUI gameUI;

    public PickupType type;
    public int healthAmount;
    public int ammoAmount;

    [Header("Bobbing Motion")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    private bool bobbingUp;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        playCon = GameObject.Find("Player").GetComponent<PlayerController>();
        gameUI = GetComponent<GameUI>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Health player = other.GetComponent<Health>();

            switch(type)
            {
                case PickupType.Health:
                player.AddHealth(healthAmount);
                break;

                case PickupType.Ammo:
                player.GiveAmmo(ammoAmount);
                break;

                default:
                print("Type not accepted.");
                break;
            }

            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight / 2, 0));
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        if(transform.position == startPos + offset)
            bobbingUp = !bobbingUp;
    }
}
