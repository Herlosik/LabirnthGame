using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;   
    public void EndGame()
    {
        CancelInvoke("Stoper");
        if(win)
        {
            Debug.Log("You Win!!! Reolad?");
        }
        else
        {
            Debug.Log("You Lose!!! Reolad");
        }
    }

    public void PauseGame()
    {
        Debug.Log("PauseGame");
        Time.timeScale = 0f;
        gamePaused= true;
    }

    public void ResumeGame()
    {
        Debug.Log("ResumeGame");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void Stoper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " s");

        if(timeToEnd <= 0)
        {
            endGame= true;

        }
        if(endGame)
        {
            EndGame();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }

        InvokeRepeating("Stoper", 2, 1);
        if(timeToEnd<= 0)
        {
            timeToEnd = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }
}
