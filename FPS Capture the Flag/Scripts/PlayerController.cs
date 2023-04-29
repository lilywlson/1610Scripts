using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Mouse Look")]
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    private float rotX;

    private Camera camera;
    private Rigidbody rb;
    // private Weapon weapon;

    void Awake()
    {
        // weapon = GetComponent<Weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();

        // GameUI.instance.UpdateScoreText(0);
        // GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 dir = transform.right * x + transform.forward * z;

        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Die()
    {
        GameManager.instance.LoseGame();

        Debug.Log("Player is dead. Game Over!");
        Time.timeScale = 0;
    }

/*
    public void GiveAmmo(int amountToGive)
    {
        // weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        // GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);

        Debug.Log("Player has collected ammo.");
    }
*/

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();

        /*
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
        */

        if(Input.GetButtonDown("Jump"))
            Jump();

        
        if(GameManager.instance.gamePaused == true)
            return;
        
    }
}
