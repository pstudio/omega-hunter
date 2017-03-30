using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreMenu : MonoBehaviour
{
    public GameObject Menu;

    public GameObject ScorePanel;
    public GameObject ShamePanel;

    public Text ScoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowScore(int score)
    {
        ScoreText.text = score.ToString();
        ScorePanel.SetActive(true);
        ShamePanel.SetActive(false);
    }

    public void ShowShame()
    {
        ShamePanel.SetActive(true);
        ScorePanel.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Menu.SetActive(true);
        ShamePanel.SetActive(false);
        gameObject.SetActive(false);
    }
}
