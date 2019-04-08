using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpRes : MonoBehaviour
{

    public Camera Cam;
    public Vector3 dir;
    public float distance = 5f;

    [Header("Resourses")]
    public static int wood;
    public static int rock;

    public Item itemWood;
    public Item itemRock;
    public Item itemAxe;
    public Item item_Altar_Key_Water;

    //Tree tree;


    void Start()
    {
        wood = 0;
        rock = 0;

        dir = Vector3.forward;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        RaycastHit hit;

        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Wood")
            {
                wood += 1;
                Debug.Log("Picking up " + itemWood.name);
                bool wasPickeUp = Inventory.instance.Add(itemWood);

                if (wasPickeUp) Destroy(hit.transform.gameObject);
            }
            if (hit.transform.tag == "Rock")
            {
                rock += 1;
                Debug.Log("Picking up " + itemRock.name);
                bool wasPickeUp = Inventory.instance.Add(itemRock);

                if (wasPickeUp) Destroy(hit.transform.gameObject);
            }
            if (hit.transform.tag == "Altar_Key_Water")
            {
                Debug.Log("Picking up " + item_Altar_Key_Water.name);
                bool wasPickeUp = Inventory.instance.Add(item_Altar_Key_Water);

                if (wasPickeUp) Destroy(hit.transform.gameObject);
            }
            if (hit.transform.tag == "Axe")
            {
                Debug.Log("Picking up " + itemAxe.name);
                bool wasPickeUp = Inventory.instance.Add(itemAxe);

                if (wasPickeUp) Destroy(hit.transform.gameObject);
            }

            if (hit.transform.tag == "Tree")
            {             

                Debug.Log("Pidorõ");
                //Tree.TreeHealth();


            }


        }
    }
}