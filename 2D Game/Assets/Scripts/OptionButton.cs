using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    private bool isPaused = false;
    public void PauseMyGame()
    {
        isPaused = !isPaused; // Toggle the pause state

        if (isPaused)
        {
            Time.timeScale = 0; // Pause the time
        }

        else
        {
            // Game is resumed
            Time.timeScale = 1; // Resume the time       
        }
    }
}
