using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float startingHealth = 100f;
    public float currentHealth;
    public GameObject healthObj;
    public float startHunger = 100f;
    public float currentHunger;
    public GameObject hungerObj;
    public float startThirst = 100f;
    public float currentThirst;
    public GameObject thirstObj;
    public float startStam = 100f;
    public float currentStam;
    public GameObject stamObj;

    //public float flashSpeed = 5f;
    //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    //public Image damageImage;
    PlayerMovement playerMovement;


    bool isDead = false;
    //bool damaged;



    void Awake()
    {
        //when game start make everything full
        currentHealth = startingHealth;
        currentHunger = startHunger;
        currentThirst = startThirst;
        currentStam = startStam;

        playerMovement = GetComponent<PlayerMovement>();

    }

    void Update()
    {
        healthObj.transform.localScale = new Vector3(currentHealth / 100, 1 , 1);
        hungerObj.transform.localScale = new Vector3(currentHunger / 100, 1 , 1);
        thirstObj.transform.localScale = new Vector3(currentThirst / 100, 1 , 1);
        stamObj.transform.localScale = new Vector3(currentStam / 100, 1 , 1);

        if (currentThirst > 0)
        {
            currentThirst -= 0.1f * Time.deltaTime;
        }

        if (currentHunger > 0)
        {
            currentHunger -= 0.1f * Time.deltaTime;
        }

        if (currentHunger <= 0 || currentThirst <= 0 && isDead == false)
        {
            TakeDamage(0.1f);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && currentStam > 0)
        {
            currentStam -= 1f;
        }
        else if (currentStam != 100f && !Input.GetKey(KeyCode.LeftShift))
        {
            currentStam += 0.5f;
        }

        currentHealth = Mathf.Clamp (currentHealth, 0 , startingHealth);
        currentHunger = Mathf.Clamp (currentHunger, 0 , startHunger);
        currentThirst = Mathf.Clamp (currentThirst, 0 , startThirst);
        currentStam = Mathf.Clamp (currentStam, 0 , startStam);


    }


    public void TakeDamage(float amount)
    {
        //damaged = true;

           currentHealth -= amount;
        
        if (currentHealth <= 0 && isDead == false)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;
        //Destroy("Player");
        playerMovement.enabled = false;
    }
}