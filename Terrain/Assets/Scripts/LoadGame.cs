using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
     //   EnableCursor();
    }
    public void RestartGame()
    {

        SceneManager.LoadSceneAsync(1);
    }
    public void GameWin()
    {
   
        SceneManager.LoadSceneAsync(2);
    }
    public void GameOverMenu()
    {

        SceneManager.LoadSceneAsync(3);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
