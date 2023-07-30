using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{



    public AudioSource Select;

    public void playgame ()
    {
        Select.Play();
        Invoke("loadScene", 0.5f);
    }

    void loadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void QuitGame ()
    {
        Select.Play();
        Invoke("endGame", 0.5f);
    
    }

    void endGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
