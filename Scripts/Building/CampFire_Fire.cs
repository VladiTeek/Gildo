using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire_Fire : MonoBehaviour
{
    [Header("3D Text")]
    //public GameObject textUI;
    //public GameObject Cam;

    [Header("Particle campfire")]
    public GameObject FirePart;
    public GameObject Lig;

    public int woodPrice2;

    //public float checkFire;

    void OnTriggerEnter(Collider other)
    {
        //textUI.gameObject.SetActive(true);
        //textUI.gameObject.transform.LookAt(Cam.transform.position);

        CampFireParticle();
    }

    void OnTriggerStay(Collider other)
    {
       //textUI.gameObject.transform.LookAt(Cam.transform.position);
        CampFireParticle();
    }

    void OnTriggerExit(Collider other)
    {
        //textUI.gameObject.transform.LookAt(Cam.transform.position);
        //textUI.gameObject.SetActive(false);
    }

    void CampFireParticle()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FirePart.SetActive(true);
            Lig.SetActive(true);
            //if (checkFire > 0)
            //{
            //    //checkFire -= 0.1f * Time.deltaTime;
            //    FirePart.SetActive(true);
            //}
            //else
            //{
            //    FirePart.SetActive(false);
            //}
        }
    }
}
