using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> hpPointsList = new List<GameObject>();
    public TextMeshProUGUI scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.uiManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableHpSprite(int value)
    {
        hpPointsList[value].SetActive(false);
    }

    public void ChangeScore()
    {
        GameManager.playerController.score += Random.Range(5, 15);
        scoreDisplay.text = "Score: " + GameManager.playerController.score;
    }
}
