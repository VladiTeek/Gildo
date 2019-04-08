using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [HideInInspector]
    public bool isPaused;

    [SerializeField]
    private GameObject Menupause;
    [SerializeField]
    private GameObject PlayerState;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            Menupause.SetActive(true);
            PlayerState.SetActive(false);

            //Time.timeScale = 0;
        }
        else
        {
            Menupause.SetActive(false);
            PlayerState.SetActive(true);

            //Time.timeScale = 1;
        }
    }
}
