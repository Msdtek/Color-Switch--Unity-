using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Controller : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1 );
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

