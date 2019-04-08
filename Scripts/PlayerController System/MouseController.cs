using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float sensitiveX = 3f;
    public float sensitiveY = 3f;

    public float minX = -360;
    public float maxX = 360;
    public float minY = -60;
    public float maxY = 60;

    private Quaternion originalRot;
    private float rotX = 0;
    private float rotY = 0;

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject Inventory;
    [SerializeField]
    private GameObject Menu_Pause;

    void Start()
    {
        originalRot = transform.localRotation;
    }

    void Update()
    {

        if (/*Inventory.activeSelf || */ Menu_Pause.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Player.GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Mouse_Controller();
            Player.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    void Mouse_Controller()
    {
        rotX += Input.GetAxis("Mouse X") * sensitiveX;
        rotY += Input.GetAxis("Mouse Y") * sensitiveX;

        rotX = rotX % 360;
        rotY = rotY % 360;

        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);

        Quaternion xQuaterion = Quaternion.AngleAxis(rotX, Vector3.up);
        Quaternion yQuaterion = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = originalRot * xQuaterion * yQuaterion;
    }
}