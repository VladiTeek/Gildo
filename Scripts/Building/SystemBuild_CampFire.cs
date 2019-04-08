using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemBuild_CampFire : MonoBehaviour
{
    [Header("Replace Object")]
    public GameObject ReplaceObject1;
    [Header("3D Text")]
    public GameObject textUI;
    public GameObject Cam;
    [Header("Price of construction")]
    public int woodPrice1;
    public int rockPrice1;

    private int woodcost = 2;
    private int rockcost = 3;

    public Item Wood;
    public Item Rock;

    private bool CheckObject = false; //Проверка построин ли объект
    private float position, position1, position2; // Позиция подсказки постройки

    void Start()
    {
        position = transform.position.x;
        position1 = transform.position.y;
        position2 = transform.position.z;
    }

    void OnTriggerEnter(Collider other)
    {
        textUI.gameObject.SetActive(true);
        textUI.gameObject.transform.LookAt(Cam.transform.position);

        if (CheckObject == false)
        {
            if (PickUpRes.wood >= woodPrice1 && PickUpRes.rock >= rockPrice1)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Build();

                    PickUpRes.wood -= woodPrice1;
                    PickUpRes.rock -= rockPrice1;

                    Debug.Log("Wood:" + PickUpRes.wood);
                    Debug.Log("Rock:" + PickUpRes.rock);

                    CheckObject = true;
                    textUI.gameObject.SetActive(false);
                }
                else
                {
                    //Debug.Log("Enter button E");
                }
            }
            else
            {
                //Debug.Log("Find resource");
            }
        }
        else
        {
            //Debug.Log("Build completed!");
        }
    }

    void OnTriggerStay(Collider other)
    {
        textUI.gameObject.transform.LookAt(Cam.transform.position);

        if (CheckObject == false)
        {
            if (PickUpRes.wood >= woodPrice1 && PickUpRes.rock >= rockPrice1)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Build();

                    PickUpRes.wood -= woodPrice1;
                    PickUpRes.rock -= rockPrice1;

                    Debug.Log("Wood:" + PickUpRes.wood);
                    Debug.Log("Rock:" + PickUpRes.rock);
                    CheckObject = true;


                    while (woodcost != woodPrice1)
                    {
                        Inventory.instance.Remove(Wood);
                        woodcost += 1;
                    }
                    while (rockcost != rockPrice1)
                    {
                        Inventory.instance.Remove(Rock);
                        rockcost += 1;
                    }

                }
                else
                {
                    //Debug.Log("Enter button E");
                }
            }
            else
            {
                //Debug.Log("Find resource");
            }
        }
        else
        {
            //Debug.Log("Build completed!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        textUI.gameObject.transform.LookAt(Cam.transform.position);
        textUI.gameObject.SetActive(false);
    }

    void Build()
    {
        if (GameObject.FindGameObjectWithTag("OpacityObject"))
        {
            Destroy(gameObject);
            Instantiate(ReplaceObject1, new Vector3(position, position1, position2), Quaternion.identity);
            //Instantiate(CampFire_2, new Vector3(position, position1 + 0.3f, position2), Quaternion.identity);
        }
    }   
}
