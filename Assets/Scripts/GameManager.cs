using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //GameManager controls switching scene, pausing and resuming game 
    public static GameManager Instance;
    [SerializeField] private GameObject gameOverWindow;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
