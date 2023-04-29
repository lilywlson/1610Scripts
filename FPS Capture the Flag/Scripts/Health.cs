using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private PlayerController playCon;

    public int currentHealth;
    public int maxHealth = 500;
    public int numberOfhearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        playCon = GameObject.Find("Player").GetComponent<PlayerController>();
        Time.timeScale = 1;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        Debug.Log("Player Health = "+ currentHealth);

        if(currentHealth <=0)
            Die();
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void GiveAmmo(int amountToGive)
    {
        // weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        // GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);

        Debug.Log("Player has collected ammo.");
    }

    void Die()
    {
        GameManager.instance.LoseGame();

        Debug.Log("Player is dead. Game Over!");
        Time.timeScale = 0;
    }

    void Update()
    {
        if(currentHealth > numberOfhearts)
        {
            currentHealth = numberOfhearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i * 100 < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numberOfhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
