using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour
{
    public static MenuScripts Instance;

    public GameObject mainMenuCanvas;
    public Button Play;

    public GameObject readyPanel;
    public GameObject playerhpCanvas;
    public GameObject gameovercanvas;
    

    public GameObject Player;

    public bool readyscreen = false;
    public bool readyonce = false;


    void Awake()
    {
        ///MenuInstance();
        Player.SetActive(false);
        readyPanel.SetActive(false);
        playerhpCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
        readyscreen = false;

    }

    void MenuInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Player.SetActive(false);
        playerhpCanvas.SetActive(false);
        readyPanel.SetActive(false);
        gameovercanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Playepressed()
    {
        Player.SetActive(true);
        playerhpCanvas.SetActive(true);
        readyPanel.SetActive(true);
        readyscreen = true;
        mainMenuCanvas.SetActive(false);
    }
    public void Restart()
    {
        Player.SetActive(true);
        playerhpCanvas.SetActive(true);
        readyPanel.SetActive(true);
        readyscreen = true;
        gameovercanvas.SetActive(false);
        mainMenuCanvas.SetActive(false);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
