using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemBuild_Well : MonoBehaviour
{
    [Header("Replace Object")]
    public GameObject ReplaceObject;
    [Header("3D Text")]
    public GameObject textUI;
    public GameObject CameraUI;
    [Header("Price of construction")]
    public int woodPrice;
    public int rockPrice;

    private int woodcost = 3;
    private int rockcost = 6;

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
        textUI.gameObject.transform.LookAt(CameraUI.transform.position);

        if (CheckObject == false)
        {
            if (PickUpRes.wood >= woodPrice && PickUpRes.rock >= rockPrice)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Build();

                    PickUpRes.wood -= woodPrice;
                    PickUpRes.rock -= rockPrice;

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
        textUI.gameObject.transform.LookAt(CameraUI.transform.position);

        if (CheckObject == false)
        {
            if (PickUpRes.wood >= woodPrice && PickUpRes.rock >= rockPrice)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Build();

                    PickUpRes.wood -= woodPrice;
                    PickUpRes.rock -= rockPrice;

                    Debug.Log("Wood:" + PickUpRes.wood);
                    Debug.Log("Rock:" + PickUpRes.rock);

                    CheckObject = true;

                    while (woodcost != woodPrice)
                    {
                        Inventory.instance.Remove(Wood);
                        woodcost += 1;
                    }
                    while (rockcost != rockPrice)
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
        textUI.gameObject.transform.LookAt(CameraUI.transform.position);
        textUI.gameObject.SetActive(false);
    }

    void Build()
    {
        if (GameObject.FindGameObjectWithTag("OpacityObject"))
        {
            Destroy(gameObject);
            Instantiate(ReplaceObject, new Vector3(position, position1, position2), Quaternion.identity);
            //Instantiate(CampFire_2, new Vector3(position, position1 + 0.3f, position2), Quaternion.identity);
        }
    }
}
