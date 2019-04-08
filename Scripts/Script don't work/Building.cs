//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using PlayeManagers;

//public class Building : MonoBehaviour
//{

//    [Tooltip("Этот материал заменяет материалы объекта")]
//    public Material Wood_Material; //Материал который будет заменять

//    private BoxCollider[] BoxCol; //Колайдеры всех объектов внутри этого префаба

//    private Renderer[] MaterialAll; // Материал всех объектов внутри этого префаба

//    private bool buildSuccess = false; //Готов ли объект

//    private GameObject parenttags;
//    private GameObject[] woodtag;

//    void Start()
//    {
//        parenttags = GameObject.FindGameObjectWithTag("ParentObject");
//        woodtag = GameObject.FindGameObjectsWithTag("Wood");

//        MaterialAll = GetComponentsInChildren<Renderer>();
//        BoxCol = GetComponentsInChildren<BoxCollider>();

//        Debug.Log("Wood:" + PlayerManager.wood);
//        Debug.Log("Rock:" + PlayerManager.rock);

//        DisableBuildCollider();
//    }


//    void Resources()
//    {
//        if (PlayerManager.wood >= 80 && PlayerManager.rock >= 20)
//        {
//            PlayerManager.wood -= 80;
//            PlayerManager.rock -= 20;

//            Debug.Log("Wood:" + PlayerManager.wood);
//            Debug.Log("Rock:" + PlayerManager.rock);
//        }
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if(buildSuccess == false)
//        {
//            if (Input.GetKeyDown(KeyCode.E))
//            {
//                Resources();
//                ReplaceMaterialWood();
//                EnableBuildCollider();
//                buildSuccess = true;
//            }
//        }
//        else
//        {
//            Debug.Log("Build completed");
//        }
//    }

//    void OnTriggerStay(Collider other)
//    {
//        if (buildSuccess == false)
//        {
//            if (Input.GetKeyDown(KeyCode.E))
//            {
//                Resources();
//                ReplaceMaterialWood();
//                EnableBuildCollider();
//                buildSuccess = true;
//            }
//        }
//        else
//        {
//            Debug.Log("Build completed");
//        }
//    }

//    void ReplaceMaterialWood()
//    {
//        for (int i = 0; i < woodtag.Length; i++)
//        {
//            MaterialAll[i].material = Wood_Material;
//        }
//    }

//    void EnableBuildCollider()
//    {
//        foreach (BoxCollider cols in BoxCol)
//        {
//            cols.enabled = enabled;
//        }
//    }

//    void DisableBuildCollider()
//    {
//        foreach (BoxCollider cols in BoxCol)
//        {
//            if (cols.enabled)
//            {
//                cols.enabled = !enabled;

//                if (parenttags == true)
//                {
//                    BoxCol[0].enabled = enabled;
//                }

//            }
//        }
//    }
//}
