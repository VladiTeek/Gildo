using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eating : MonoBehaviour
{
    public Camera Cam;
    public Vector3 dir;
    public float distance = 5f;

    private PlayerHealth playerHealth;

    void Start()
    {
        dir = Vector3.forward;
    }

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.E))
        {
            Meat();
        }
    }

    void Meat()
    {
        RaycastHit hit;

        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Food" && playerHealth.currentHunger < 90)
            {
                //Destroy(hit.transform.gameObject);
                playerHealth.currentHunger += 10f;
                Destroy(hit.transform.gameObject);
            }
            else if (hit.transform.tag == "Vater" && playerHealth.currentThirst < 90)
            {
                //Destroy(hit.transform.gameObject);
                playerHealth.currentThirst += 5f;
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
