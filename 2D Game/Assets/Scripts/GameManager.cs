using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public static bool isPaused = false; // made globally accessible so that my player script can access it
    public static GameManager Instance;

    private void Start()
    {
        // Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked; // locking cursor
    }
    private void Update()
    {
        if (gameOver.activeInHierarchy)
        {
            // Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused; // Toggle the pause state

        if (isPaused)
        {
            //MainController.Instance.SoundManager.ToggleMusicMute;
            Time.timeScale = 0; // Pause the time
            gameOver.SetActive(true); // Show the pause UI  
        }
        else
        {
            //MainController.Instance.SoundManager.ToggleMusicMute(false);
            // Game is resumed
            Time.timeScale = 1; // Resume the time
            gameOver.SetActive(false); // Hide the pause UI           
        }
    }

    public void PlayGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        MainController.Instance.SoundManager.MUSIC_Source.Stop();

    }
    public void Restart()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        MainController.Instance.SoundManager.MUSIC_Source.Stop();
        MainController.Instance.SoundManager.MUSIC_Source.Play();
        MainController.Instance.SoundManager.ToggleMusicMute(false);

    }
    public void MainMenu()
    {
        MainController.Instance.SoundManager.MUSIC_Source.Stop();
        MainController.Instance.SoundManager.MUSIC_Source.Play();
        MainController.Instance.SoundManager.ToggleMusicMute(false);
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("game quit");
    }
}
