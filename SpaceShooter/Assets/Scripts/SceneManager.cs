using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreDisplay;

    void Start()
    {
        GameManager.sceneManager = this;
        int score = PlayerPrefs.GetInt("score");
        scoreDisplay.text = "Zdobyte Punkty: "+score;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void Over()
    {
        SceneManager.LoadScene("Over");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
