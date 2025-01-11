using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu: MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    private bool isGamePause = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            isGamePause = !isGamePause;
            PauseGame();
        }
    }


    public void PauseGame()
    {
        if (isGamePause) 
        {

            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);

        }
    }
}
