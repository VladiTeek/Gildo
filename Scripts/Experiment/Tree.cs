using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tree : MonoBehaviour
{
    int Healt = 3;

    public void TreeHealth(int g)
    {
        Healt -= g;
        Debug.Log("_!_");
        if (Healt == 0)
        {
            Destroy(gameObject);
        }
    }
    
}