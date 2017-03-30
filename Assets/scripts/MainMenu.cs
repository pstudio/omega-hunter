using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject Game;
    public GameObject MenuPanel;
    public GameObject AboutPanel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BeginGame()
    {
        Game.SetActive(true);
        gameObject.SetActive(false);
    }

    public void AboutGame()
    {
        AboutPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }

    public void CloseAbout()
    {
        MenuPanel.SetActive(true);
        AboutPanel.SetActive(false);
    }
}
