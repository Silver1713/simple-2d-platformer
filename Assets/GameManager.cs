using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Configurations")]
    [HideInInspector]public static GameManager instance;
    [Tooltip("Player Score")] public int playerScore;
    [Tooltip("Gui Canvas")] public Canvas Gui;
    public GameObject plr;
    public GameObject Killer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        
    }

    private void Start()
    {
        playerScore = 0;
        AssignPointToGui();
    }

    public void AddScore(int points)
    {
        if (playerScore != -1)
        {
            playerScore++;
            AssignPointToGui();
        }
    }
    void AssignPointToGui()
    {
        GameObject currentPoint = Gui.transform.Find("ScoreText").gameObject;
        Text currentText = currentPoint.GetComponent<Text>();
        currentText.text = playerScore.ToString();
    }

    public void callGameOver()
    {
        plr.transform.Find("Main Camera").SetParent(null);
        Destroy(plr);
        Destroy(Killer);

        GameObject GameOverUI = Gui.transform.Find("GameOverText").gameObject;
        GameOverUI.SetActive(true);
        
    }


}