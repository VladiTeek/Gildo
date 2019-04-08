using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    Animation anim;

    public GameObject panel_set;

    private bool inventoryIsopened;
    private bool settingsOpen;
    private bool pauseBut;
    private bool playIsopened;

    Animation animsP;

    public GameObject[] pausesButton;
    public GameObject newGame;
    public GameObject inventorys;

    public int gameStatusCount;

    void Awake()
    {
        anim = GetComponent<Animation>();

        //inventorys.SetActive(false);

        //gameStatusCount  = FindObjectsOfType<Canvas>().Length;
        //gameObject.SetActive(checks);
        //DontDestroyOnLoad(gameObject);
    }

    public void PlayGame()
    {
        anim.Play("Play_But_1");
    }

    public void StartLevel()
    {
        if (!playIsopened)
        {
            newGame.SetActive(true);
        }
        else
        {
            newGame.SetActive(false);
        }
        playIsopened = !playIsopened;
    }

    public void NewGameEasy() 
    {
        SceneManager.LoadScene("SceneEasy");
    }

    public void NewGameMedium()
    {
        SceneManager.LoadScene("SceneMedium");
    }

    public void NewGameHard()
    {
        SceneManager.LoadScene("SceneHard");
    }

    public void Continue()
    {
        anim.Play("Continue_But_1");
    }

    public void ContinueMain(GameObject obj)
    {
        obj = GameObject.Find("Manager");
        obj.GetComponent<Pause>().isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseMenu()
    {
        //anim.Play("Pause_But_1");
        pausesButton[0].SetActive(false);
        pausesButton[1].SetActive(true);

        Time.timeScale = 0;

        //if (!pauseBut)
        //{
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //}
        //pauseBut = !pauseBut;
    }

    public void PauseMenu1()
    {
        pausesButton[0].SetActive(true);
        pausesButton[1].SetActive(false);

        Time.timeScale = 1;
    }

    public void InventoryGame()
    {
        anim.Play("Inventory_But_1");
    }

    public void InventoryOpen()
    {
        if(!inventoryIsopened)
        {
            inventorys.SetActive(true);
        }
        else
        {
            inventorys.SetActive(false);
        }
        inventoryIsopened = !inventoryIsopened;
    }

    public void PauseGame()
    {
        if (!pauseBut)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        pauseBut = !pauseBut;
    }

    public void LoadGame()
    {
        anim.Play("Load_But_1");
    }

    public void MainLoadButton()
    {
        anim.Play("LoadButton_M");
    }

    public void SaveGame() 
    {
        anim.Play("Save_But_1");
    }

    public void ExitGame()
    {
        anim.Play("Exit_But_1");
    }

    public void ExGame()
    {
        Application.Quit();
        Debug.Log("Hi");
    }

    public void OpenSettings()
    {
        panel_set = GameObject.Find("SettingsPanel");

        animsP = panel_set.GetComponent<Animation>();
        anim.Play("SettingBut_1");

        if (!settingsOpen)
        {
            animsP.Play("Settings_Panel_1");
        }
        else
        {
            animsP.Play("Settings_Panel_2");
        }
        settingsOpen = !settingsOpen;
    }
}
