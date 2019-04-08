using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public void ExitMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Continue(GameObject obj)
    {
        obj.GetComponent<Pause>().isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
